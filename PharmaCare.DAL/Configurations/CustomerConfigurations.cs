using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
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


        // Relations

            // customer has chat ( 1 to 1 )
            builder.HasOne(c => c.Chat)
                   .WithOne(ch => ch.Customer)
                   .HasForeignKey<Chat>(ch => ch.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Customer Has ShoppingCart (1 to 1) 
            builder.HasOne(c => c.ShoppingCart)
                   .WithOne(sh => sh.Customer)
                   .HasForeignKey<ShoppingCart>(sh => sh.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // customer Receive Purchase ( 1 to N)
            builder.HasMany(c => c.Purchases)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Customer Make Review (1 to N)
            builder.HasMany(c => c.Reviews)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Customer upload prescription (1 to N)
            builder.HasMany(c => c.Prescriptions)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Customer Take Order ( 1 to N)
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
