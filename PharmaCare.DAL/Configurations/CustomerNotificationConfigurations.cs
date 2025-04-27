using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Configurations
{
    public class CustomerNotificationConfigurations : IEntityTypeConfiguration<CustomerNotification>
    {
        public void Configure(EntityTypeBuilder<CustomerNotification> builder)
        {
            builder.HasOne(cn => cn.Customer)
                .WithMany(c => c.CustomerNotifications)
                .HasForeignKey(cn => cn.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
