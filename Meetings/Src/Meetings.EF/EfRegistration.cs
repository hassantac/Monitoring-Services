using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetings.EF
{
    public static class EfRegistration
    {
        #region Methods

        public static void AddEf(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<MeetingsContext>();
        }

        #endregion Methods
    }
}