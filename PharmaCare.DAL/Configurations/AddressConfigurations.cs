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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedById);
            builder.Property(x => x.CreatedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.CreatedDateTime)
                   .HasColumnType("DATE");


            builder.Property(x => x.ModifiedById);
            builder.Property(x => x.ModifiedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.ModifiedDateTime)
                   .HasColumnType("DATE");


            builder.Property(x => x.DeletedById);
            builder.Property(x => x.DeletedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.DeletedDateTime)
                   .HasColumnType("DATE");

            builder.Property(x=>x.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnType("BIT");


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
