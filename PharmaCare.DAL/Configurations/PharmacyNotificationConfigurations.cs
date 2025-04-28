using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Configurations
{
    public class PharmacyNotificationConfigurations : IEntityTypeConfiguration<PharmacyNotification>
    {
        public void Configure(EntityTypeBuilder<PharmacyNotification> builder)
        {
            builder.HasOne(phN => phN.Pharmacy)
                   .WithMany(ph => ph.PharmacyNotifications)
                   .HasForeignKey(phN => phN.PharmacyId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
