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

            builder.HasDiscriminator<UserType>(nameof(Address.UserType))
                   .IsComplete(false);

            // Relations



        }
    }
}
