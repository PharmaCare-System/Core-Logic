using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class ProductOrderConfigurations : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(po => new { po.ProductId, po.OrderId });

            builder.HasOne(po => po.Product)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(po => po.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
