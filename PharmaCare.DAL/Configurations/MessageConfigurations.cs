using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Configurations
{
    public class MessageConfigurations : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {

            builder.HasKey(x => x.Id);


            builder.Property(x => x.CreatedDateTime)

                   .HasColumnType("DATE");


            
            builder.Property(x => x.ModifiedDateTime)
                   .HasColumnType("DATE");

            builder.Property(x => x.DeletedDateTime)
                   .HasColumnType("DATE");

            builder.Property(x => x.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnType("BIT");
            //---------------------

            builder.Property(m => m.MessageText)
                   .IsRequired();

            builder.Property(m=>m.MessageDate)
                .HasColumnType("DATE")
                .IsRequired();

            // relations: THP (customer and pharmacist)
            builder.HasDiscriminator<UserType>(nameof(Messages.UserType))
                   .HasValue<MessagesCustomer>(UserType.Customer)
                   .HasValue<MessagesPharmacist>(UserType.Pharmacist);
        }
    }
}
