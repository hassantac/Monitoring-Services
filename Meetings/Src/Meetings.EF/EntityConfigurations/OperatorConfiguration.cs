﻿using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class OperatorConfiguration : IEntityTypeConfiguration<Operator>
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

        public void Configure(EntityTypeBuilder<Operator> builder)
        {

            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasIndex(h => h.Id)
                .IsUnique();
        }

        #endregion
    }
}
