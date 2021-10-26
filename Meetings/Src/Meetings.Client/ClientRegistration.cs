using Meetings.Client.Implementation.Unit;
using Meetings.Client.Interface.Unit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Client
{
    public static class ClientRegistration
    {
        #region Methods

        public static void AddClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientUnit, ClientUnit>();
        }

        #endregion Methods
    }
}