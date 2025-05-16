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
    public class PharmacyConfigurations : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
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

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150); 

            builder.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(250);


            builder.HasMany(p => p.purchases)
                .WithOne(p => p.Pharmacy) 
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(p => p.inventory)
                .WithOne(i => i.Pharmacy) 
                .HasForeignKey<Inventory>(i => i.PharmacyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Pharmacists)
                .WithOne(p => p.Pharmacy)
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p=>p.ManagerPharmacy)
                   .WithOne(ph => ph.ManagedPharmacy)
                   .HasForeignKey<Pharmacy>(p => p.MangerPharmacyId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
