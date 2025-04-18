using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.UserAddress;

namespace PharmaCare.DAL.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.Property(a => a.streetNumber)
                    .HasColumnType("SMALLINT")
                    .IsRequired();

            builder.Property(a => a.Country)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(a => a.City)
                    .HasMaxLength(50)
                    .IsRequired();


            // Relations
            builder.HasDiscriminator<UserType>(nameof(Address.UserType))
                   .HasValue<CustomerAddress>(UserType.Customer)
                   .HasValue<PharmacistAddress>(UserType.Pharmacist);         


        }
    }

}
