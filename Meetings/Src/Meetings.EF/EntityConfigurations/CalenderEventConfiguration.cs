using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class CalenderEventConfiguration : IEntityTypeConfiguration<CalenderEvent>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<CalenderEvent> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasIndex(h => h.Id)
                .IsUnique();
        }

        #endregion Methods
    }
}