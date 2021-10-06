﻿using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class SubjectClassConfiguration : IEntityTypeConfiguration<SubjectClass>
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

        public void Configure(EntityTypeBuilder<SubjectClass> builder)
        {

            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasIndex(h => h.Id)
                .IsUnique();

            builder.HasOne(h => h.Subject)
                .WithMany(w => w.SubjectClasses)
                .HasForeignKey(h => h.Subject_Id);


            builder.HasOne(h => h.ClassOfSchool)
                   .WithMany(w => w.SubjectClasses)
                   .HasForeignKey(h => h.Class_Id);
        }

        #endregion
    }
}