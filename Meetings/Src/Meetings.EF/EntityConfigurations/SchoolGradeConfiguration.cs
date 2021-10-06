using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class SchoolGradeConfiguration : IEntityTypeConfiguration<SchoolGrade>
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

        public void Configure(EntityTypeBuilder<SchoolGrade> builder)
        {

            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasIndex(h => h.Id)
                .IsUnique();

            builder.HasOne(h => h.School)
                .WithMany(w => w.SchoolGrades)
                .HasForeignKey(h => h.School_Id);


            builder.HasOne(h => h.Grade)
                   .WithMany(w => w.SchoolGrades)
                   .HasForeignKey(h => h.Grade_Id);
        }

        #endregion
    }
}
