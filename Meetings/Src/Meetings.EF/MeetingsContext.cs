using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Meetings.EF
{
    public class MeetingsContext : DbContext
    {
        #region Properties

        #region DbSets

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }
        public virtual DbSet<CalenderEvent> CalenderEvents { get; set; }

        #endregion DbSets

        #endregion Properties



        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettingHelper.GetDefaultConnection());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());
            modelBuilder.ApplyConfiguration(new CalenderEventConfiguration());
        }

        #endregion Methods
    }
}