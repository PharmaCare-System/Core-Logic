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
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
