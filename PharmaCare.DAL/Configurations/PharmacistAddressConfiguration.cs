using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserAddress;

namespace PharmaCare.DAL.Configurations
{
    public class PharmacistAddressConfiguration : IEntityTypeConfiguration<PharmacistAddress>
    {
        public void Configure(EntityTypeBuilder<PharmacistAddress> builder)
        {
            builder.HasOne(a => a.Pharmacist)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(a => a.UserId);
        }
    }
}
