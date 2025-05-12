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

            builder.Property(x => x.CreatedById)
                   .IsRequired();
            builder.Property(x => x.CreatedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.CreatedDateTime)
                   .IsRequired()
                   .HasColumnType("DATE");


            builder.Property(x => x.ModifiedById)
                   .IsRequired();
            builder.Property(x => x.ModifiedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.ModifiedDateTime)
                   .IsRequired()
                   .HasColumnType("DATE");


            builder.Property(x => x.DeletedById)
                   .IsRequired();
            builder.Property(x => x.DeletedByName)
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(x => x.DeletedDateTime)
                   .IsRequired()
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
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(p => p.inventory)
                .WithOne(i => i.Pharmacy) 
                .HasForeignKey<Inventory>(i => i.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Pharmacists)
                .WithOne(p => p.Pharmacy)
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p=>p.ManagerPharmacy)
                   .WithOne(ph => ph.ManagedPharmacy)
                   .HasForeignKey<Pharmacy>(p => p.MangerPharmacyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
