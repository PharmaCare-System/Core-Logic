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
    public class PharmacyConfigrations : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ManagerPharmacy)
                .IsRequired();

            builder.HasMany(p => p.purchases)
                .WithOne(p => p.Pharmacy) 
                .HasForeignKey(p => p.PharamcyId)
                .OnDelete(DeleteBehavior.SetNull); 

            builder.HasOne(p => p.inventory)
                .WithOne(i => i.Pharmacy) 
                .HasForeignKey<Inventory>(i => i.PharmacyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Pharmacists)
                .WithOne(p => p.Pharmacy)
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.ManagerPharmacy)
                .WithOne(p => p.Pharmacy)
                .HasForeignKey<Pharmacist>(p => p.PharmacyId);

        }
    }
}
