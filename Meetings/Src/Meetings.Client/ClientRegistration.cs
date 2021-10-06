using Meetings.Client.Implementation.Unit;
using Meetings.Client.Interface.Unit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetings.Client
{
    public static class ClientRegistration
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

        public static void AddClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientUnit, ClientUnit>();
        }

        #endregion
    }
}
