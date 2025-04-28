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
                .HasMaxLength(250);



            // relations


            builder.HasMany(i => i.Products)
                .WithOne(p => p.Inventory)
                .HasForeignKey(p => p.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
