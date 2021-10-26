using Meetings.Repositories;
using Meetings.Services.Implementation.Unit;
using Meetings.Services.Interface.Unit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Services
{
    public static class ServiceRegistration
    {
        #region Methods

        public static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);

            services.AddScoped<IServiceUnit, ServiceUnit>();
        }

        #endregion Methods
    }
}