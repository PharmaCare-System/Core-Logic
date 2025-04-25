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

            // customer has chat ( 1 to 1 )
            builder.HasOne(c => c.Chat)
                   .WithOne(ch => ch.Customer)
                   .HasForeignKey<Chat>(ch => ch.CustomerId);

            // Customer Has ShoppingCart (1 to 1) 
            builder.HasOne(c => c.ShoppingCart)
                   .WithOne(sh => sh.Customer)
                   .HasForeignKey<ShoppingCart>(sh => sh.CustomerId);

            // customer Receive Purchase ( 1 to N)
            builder.HasMany(c => c.Purchases)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId);

            // Customer Make Review (1 to N)
            builder.HasMany(c => c.Reviews)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId);

            // Customer upload prescription (1 to N)
            builder.HasMany(c => c.Prescriptions)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.CustomerId);

            // Customer Take Order ( 1 to N)
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId);
        }
    }
}
