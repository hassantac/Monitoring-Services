using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.HasIndex(h => h.Id)
                .IsUnique();

            builder.HasOne(h => h.CalenderEvent)
                   .WithMany(w => w.UserEvents)
                   .HasForeignKey(h => h.Event_Id);

            builder.HasOne(h => h.User)
                   .WithMany(w => w.UserEvents)
                   .HasForeignKey(h => h.User_Id);
        }

        #endregion Methods
    }
}