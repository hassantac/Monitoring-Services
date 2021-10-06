using Meetings.Repositories;
using Meetings.Services.Implementation.Unit;
using Meetings.Services.Interface.Unit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetings.Services
{
    public static class ServiceRegistration
    {
        #region Private Fields

        #endregion


        #region Private Methods

        #endregion


        #region Constructors

        #endregion


        #region Properties

        #endregion


        #region Fields

        #endregion


        #region Methods

        public static void AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);

            services.AddScoped<IServiceUnit, ServiceUnit>();
        }

        #endregion
    }
}
