using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Configurations
{
    public class CustomerMessageConfigurations : IEntityTypeConfiguration<MessagesCustomer>
    {
        public void Configure(EntityTypeBuilder<MessagesCustomer> builder)
        {
            builder.HasOne(mc => mc.Customer)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
