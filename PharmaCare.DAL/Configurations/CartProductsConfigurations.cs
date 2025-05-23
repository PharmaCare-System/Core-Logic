using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Configurations
{
    public class CartProductsConfigurations : IEntityTypeConfiguration<CartProducts>
    {
        public void Configure(EntityTypeBuilder<CartProducts> builder)
        {
            builder.HasKey(cp => new { cp.ProductId, cp.CartId });
        }
    }
}
