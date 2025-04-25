using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Location)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(i => i.QuantityStock)
                .IsRequired()
                .HasDefaultValue(0);
            builder.HasOne(i => i.Pharmacy)
               .WithOne(p => p.inventory)
               .HasForeignKey<Inventory>(i => i.PharmacyId)
               .OnDelete(DeleteBehavior.SetNull); 

            builder.HasMany(i => i.Notifications)
                .WithOne(n => n.Inventory)
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(i => i.Products)
                .WithOne(p => p.Inventory)
                .HasForeignKey(p => p.InventoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
