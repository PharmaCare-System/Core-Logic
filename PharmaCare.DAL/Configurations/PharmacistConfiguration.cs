using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.UserAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Configurations
{
    public class PharmacistConfiguration : IEntityTypeConfiguration<Pharmacist>
    {
        public void Configure(EntityTypeBuilder<Pharmacist> builder)
        {

            builder.Property(c => c.Age)
                   .HasComputedColumnSql("DATEDIFF(YEAR, [Birthday], GETDATE()) - ", stored: true);

            builder.Property(c => c.Password)
                   .HasMaxLength(100).IsRequired();

            builder.Property(c => c.Email)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(c => c.FirstName)
                    .HasMaxLength(25)
                    .IsRequired();
            builder.Property(c => c.LastName)
                    .HasMaxLength(25)
                    .IsRequired();

            builder.Property(c => c.Phone)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(c => c.Birthday)
                    .HasColumnType("DATE")
                    .IsRequired();

            // Relations


            // Pharmacist send messages ( 1 to N): will be converted to THP relation


            // pharmacist Access Chat (N to N):
            builder.HasMany(p => p.Chats)
                   .WithMany( c => c.pharmacists)
                   .UsingEntity<PharmacistChats>();

            // customer Review Purchase ( 1 to N)
            builder.HasMany(p => p.Prescriptions)
                   .WithOne(pr => pr.Pharmacist)
                   .HasForeignKey(pr => pr.PharamcistId);

            // pharmacist process Order ( 1 to N)
            builder.HasMany(p => p.Orders)
                   .WithOne(o => o.Pharmacist)
                   .HasForeignKey(o => o.PharmacistId);

            // pharmacist is manager ( 1 to 1)
            builder.HasOne(p => p.Pharmacy)
                   .WithOne(ph => ph.ManagerPharmacy)
                   .HasForeignKey<Pharmacy>(ph => ph.MangerPharmacyId);

            // pharmacist work in pharmacy (1 to N)
            builder.HasOne(p => p.Pharmacy)
                   .WithMany(ph=>ph.Pharmacists)
                   .HasForeignKey(p=>p.PharmacyId);



        }
    }
}
