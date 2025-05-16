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

            builder.Property(x => x.CreatedById);
            builder.Property(x => x.CreatedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.CreatedDateTime)
                   .HasColumnType("DATE");


            builder.Property(x => x.ModifiedById);
            builder.Property(x => x.ModifiedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.ModifiedDateTime)
                   .HasColumnType("DATE");


            builder.Property(x => x.DeletedById);
            builder.Property(x => x.DeletedByName)
                   .HasMaxLength(15);
            builder.Property(x => x.DeletedDateTime)
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
