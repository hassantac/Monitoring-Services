using Meetings.DTO.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetings.EF.EntityConfigurations
{
    internal class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
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

        #endregion
    }
}
