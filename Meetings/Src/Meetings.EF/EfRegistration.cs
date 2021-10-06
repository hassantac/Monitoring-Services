using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.EF
{
    public static class EfRegistration
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

        public static void AddEf(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<MeetingsContext>();
        }

        #endregion
    }
}
