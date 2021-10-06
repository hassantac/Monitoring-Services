using Meetings.EF;
using Meetings.Repositories.Implementation.Unit;
using Meetings.Repositories.Interface.Unit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.Repositories
{
    public static class RepositoryRegistration
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

        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEf(configuration);

            services.AddScoped<IRepositoryUnit, RepositoryUnit>();
        }

        #endregion
    }
}
