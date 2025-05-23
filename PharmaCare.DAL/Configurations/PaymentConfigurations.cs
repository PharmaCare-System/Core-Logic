using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
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

            builder.Property(p => p.Type)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(p => p.Status)
                   .HasConversion<string>()
                   .IsRequired();
        }
    }
}
