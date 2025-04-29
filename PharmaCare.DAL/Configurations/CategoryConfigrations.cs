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
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
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
            builder.Property(c => c.CategoryName)
                   .HasMaxLength(250).IsRequired();
        }
    }
}
