using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Meetings.EF
{
    public class MeetingsContext : DbContext
    {
        #region Private Fields

        #endregion


        #region Private Methods

        #endregion


        #region Constructors

        #endregion


        #region Properties

        #region DbSets

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<ClassOfSchool> ClassesOfSchool { get; set; }
        public virtual DbSet<SubjectClass> SubjectClasses { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SchoolGrade> SchoolGrades { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }
        public virtual DbSet<CalenderEvent> CalenderEvents { get; set; }

        #endregion

        #endregion


        #region Fields

        #endregion


        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettingHelper.GetDefaultConnection());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new OperatorConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new ClassOfSchoolConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectClassConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolGradeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEventConfiguration());
            modelBuilder.ApplyConfiguration(new CalenderEventConfiguration());
        }
        #endregion

    }
}
