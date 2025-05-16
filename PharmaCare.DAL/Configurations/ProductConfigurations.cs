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
                                .HasForeignKey(pc => pc.CategoryId)
                                .OnDelete(DeleteBehavior.NoAction),

                        pp => pp.HasOne(pc => pc.Product)
                                .WithMany(p => p.ProductCategories)
                                .HasForeignKey(pc=>pc.ProductId)
                                .OnDelete(DeleteBehavior.NoAction)
                   );

            builder.HasMany(p => p.Orders)
                   .WithMany(o => o.Products)
                   .UsingEntity<ProductOrder>(
                        j => j.HasOne(po => po.Order)
                              .WithMany(o => o.ProductOrders)
                              .HasForeignKey(po => po.OrderRefId)
                              .OnDelete(DeleteBehavior.NoAction),
                        j => j.HasOne(po => po.Product)
                              .WithMany(p => p.ProductOrders)
                              .HasForeignKey(po => po.ProductId)
                              .OnDelete(DeleteBehavior.NoAction),
                        j => j.HasKey(po => new { po.ProductId, po.OrderRefId })
                   );
        }
    }
}
