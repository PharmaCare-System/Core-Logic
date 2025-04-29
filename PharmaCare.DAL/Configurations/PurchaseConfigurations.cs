using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class PurchaseConfigurations : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedById)
                   .IsRequired();
            builder.Property(x => x.CreatedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.CreatedDateTime)
                   .IsRequired()
                   .HasColumnType("DATE");


            builder.Property(x => x.ModifiedById)
                   .IsRequired();
            builder.Property(x => x.ModifiedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.ModifiedDateTime)
                   .IsRequired()
                   .HasColumnType("DATE");


            builder.Property(x => x.DeletedById)
                   .IsRequired();
            builder.Property(x => x.DeletedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.DeletedDateTime)
                   .IsRequired()
                   .HasColumnType("DATE");

            builder.Property(x => x.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnType("BIT");
            //---------------------

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
