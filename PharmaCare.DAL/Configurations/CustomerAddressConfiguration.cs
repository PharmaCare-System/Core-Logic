using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserAddress;

namespace PharmaCare.DAL.Configurations
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasOne(a => a.Customer)
                .WithOne(c => c.Address)
                .HasForeignKey<CustomerAddress>(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
