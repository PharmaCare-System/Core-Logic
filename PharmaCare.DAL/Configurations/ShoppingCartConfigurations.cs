using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Configurations
{
    public class ShoppingCartConfigurations : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.Property(sh => sh.CreatedAt)
                   .HasColumnType("DATE")
                   .IsRequired();

            // relations
            builder.HasMany(sh => sh.Products)
                   .WithMany(p => p.ShoppingCarts)
                   .UsingEntity<CartProducts>(
                        pp => pp.HasOne(c=>c.Product)
                                .WithMany(p=>p.CartProducts)
                                .OnDelete(DeleteBehavior.Cascade),

                        cc => cc.HasOne(c=>c.ShoppingCart)
                                .WithMany(sp=>sp.CartProducts)
                                .OnDelete(DeleteBehavior.Cascade)
                    );
        }
    }
}
