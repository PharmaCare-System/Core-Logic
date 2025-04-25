using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class PurchaseConfigurations : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.Property(p => p.PaymentStatus)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(p=>p.TotalCost)
                   .IsRequired();

            builder.Property(p=>p.IsVendor)
                   .HasColumnType("BIT")
                   .IsRequired();

            builder.Property(p => p.PurchaseDate)
                   .HasColumnType("DATE")
                   .IsRequired();

            // relations
            builder.HasOne(p => p.Payment)
                   .WithOne(p => p.Purchase)
                   .HasForeignKey<Purchase>(p => p.PaymentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
