using Hangfire;
using Meetings.API.Filters;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Implementation.Unit;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.Client;
using Meetings.Common.Helper;
using Meetings.EF;
using Meetings.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Meetings.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    return CustomErrorResponse(actionContext);
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Meetings API",
                    Description = "Meetings Doc",
                    Version = "v1"
                });

                // XML Doc
                string xmlDocFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlDocFilePath = Path.Combine(AppContext.BaseDirectory, xmlDocFileName);
                options.IncludeXmlComments(xmlDocFilePath);
            });


            services.AddHangfire(options => options.UseSqlServerStorage(AppSettingHelper.GetHangFireConnection()));
            services.AddHangfireServer();


            // Add Service
            services.AddService(Configuration);
            services.AddClient(Configuration);

            // Add Filter
            services.AddScoped<CheckJwtFilter>();

            // Add Object Converter
            services.AddScoped<IConverterUnit, ConverterUnit>();

            services.AddResponseCompression(option => option.Providers.Add<GzipCompressionProvider>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();

            InitializeDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (AppSettingHelper.GetEnableSwagger())
            {
                app.UseSwagger();

                app.UseSwaggerUI(option =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(option.RoutePrefix) ? "." : "..";
                    option.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "AList Swagger Doc");
                });
            }
        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<MeetingsContext>().Database.Migrate();
        }
        private BadRequestObjectResult CustomErrorResponse(ActionContext action)
        {
            var res = new ResponseWrapper<object>
            {
                Success = false,
                Message = MessageHelper.InvalidBody,
                Error = new ErrorResponse()
            };
            foreach (var item in action.ModelState)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    res.Error.ErrorMessage += $"{ item.Value.Errors.First().ErrorMessage}\n";
                }
            }

            return new BadRequestObjectResult(res);
        }
    }
}
