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


            builder.Property(c => c.Age)
                   .HasComputedColumnSql("DATEDIFF(YEAR, [Birthday], GETDATE())", false);

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

            // pharmacist Review prescriptions ( 1 to N)
            builder.HasMany(p => p.Prescriptions)
                   .WithOne(pr => pr.Pharmacist)
                   .HasForeignKey(pr => pr.PharmacistId)
                   .OnDelete(DeleteBehavior.SetNull);

            // pharmacist process Order ( 1 to N)
            builder.HasMany(p => p.Orders)
                   .WithOne(o => o.Pharmacist)
                   .HasForeignKey(o => o.PharmacistId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
