using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price)
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.ExpiryDate)
                   .HasColumnType("DATE")
                   .IsRequired();

            builder.Property(p => p.QuantityInStock)
                   .IsRequired();

            builder.Property(p => p.BulkAllowed)
                   .HasColumnType("BIT")
                   .IsRequired();

            builder.Property(p => p.PrescriptionRequired)
                   .HasColumnType("BIT")
                   .IsRequired();
            
            builder.Property(p => p.BarCode)
                    .IsRequired(false);
            
            builder.Property(p => p.ImageURL)
                   .IsRequired(false);


            // relations
            builder.HasMany(p => p.Categories)
                   .WithMany(c => c.Products)
                   .UsingEntity<ProductCategory>(
                        cc => cc.HasOne(pc => pc.Category)
                                .WithMany(c => c.ProductCategories)
                                .OnDelete(DeleteBehavior.Cascade),

                        pp => pp.HasOne(pc => pc.Product)
                                .WithMany(p => p.ProductCategories)
                                .OnDelete(DeleteBehavior.Cascade)
                   );

            builder.HasMany(o => o.Orders)
                   .WithMany(p => p.Products)
                   .UsingEntity<ProductOrder>(
                        pp => pp.HasOne(po => po.Order)
                                .WithMany(o => o.ProductOrders)
                                .OnDelete(DeleteBehavior.Cascade),

                        oo => oo.HasOne(po => po.Product)
                                .WithMany(p => p.ProductOrders)
                                .OnDelete(DeleteBehavior.Cascade)
                   );
        }
    }
}
