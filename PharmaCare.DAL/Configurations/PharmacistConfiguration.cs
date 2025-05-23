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


            // Relations

            // pharmacist Review prescriptions ( 1 to N)
            builder.HasMany(p => p.Prescriptions)
                   .WithOne(pr => pr.Pharmacist)
                   .HasForeignKey(pr => pr.PharmacistId);

            // pharmacist process Order ( 1 to N)
            builder.HasMany(p => p.Orders)
                   .WithOne(o => o.Pharmacist)
                   .HasForeignKey(o => o.PharmacistId)
                   .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
