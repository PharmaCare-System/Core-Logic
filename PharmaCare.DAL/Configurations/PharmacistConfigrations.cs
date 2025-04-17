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
    public class PharmacistConfigrations : IEntityTypeConfiguration<Pharmacist>
    {
        public void Configure(EntityTypeBuilder<Pharmacist> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(p => p.Address)
                .HasMaxLength(200);
            builder.Property(p=> p.Password)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.HireDate).HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.pharmacy)
                .WithMany(p => p.pharmacists)
                .HasForeignKey(p => p.PharmacyId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p => p.messages)
                .WithOne(m => m.Pharmacist)
                .HasForeignKey(m => m.PharmacistId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Prescriptions)
               .WithOne(pr => pr.Pharmacist)
               .HasForeignKey(pr => pr.PharmacistId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Orders)
                .WithOne(o => o.Pharmacist)
                .HasForeignKey(o => o.PharmacistId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(p => p.ManagerPharmacist)
                .WithMany(p => p.Pharmacists)
                .HasForeignKey(p => p.ManagerPharmacistId);
        }

    }
}
