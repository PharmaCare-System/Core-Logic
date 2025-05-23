using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Configurations
{
    public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
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

            builder.Property(p => p.Status)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(p => p.UploadDate)
                   .HasConversion<DateTime>()
                   .IsRequired();
        }
    }
}
