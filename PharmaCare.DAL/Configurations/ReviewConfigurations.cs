using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class ReviewConfigurations : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.ReviewDate)
                   .HasColumnType("DATE")
                   .IsRequired();

            builder.Property(r => r.Rating)
                   .HasColumnType("TINYINT")
                   .IsRequired();

            builder.Property(r => r.Comment)
                   .HasColumnType("NVARCHAR")
                   .IsRequired(false);


            // relations
            // reviews are in product
            builder.HasOne(r => r.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.ProductId);
        }
    }
}
