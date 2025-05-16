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

            builder.Property(sh => sh.CreatedAt)
                   .HasColumnType("DATE");

            // relations
            builder.HasMany(sh => sh.Products)
                   .WithMany(p => p.ShoppingCarts)
                   .UsingEntity<CartProducts>(
                        pp => pp.HasOne(c => c.Product)
                                .WithMany(p => p.CartProducts)
                                .HasForeignKey(c => c.ProductId)
                                .OnDelete(DeleteBehavior.NoAction),

                        cc => cc.HasOne(c => c.ShoppingCart)
                                .WithMany(sp => sp.CartProducts)
                                .HasForeignKey(c => c.CartId)
                                .OnDelete(DeleteBehavior.NoAction)
                    );
        }
    }
}
