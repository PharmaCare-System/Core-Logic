using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
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

            builder.Property(o => o.OrderType)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(o => o.OrderStatus)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(c => c.DeliveryAddress)
                    .HasMaxLength(250)
                    .IsRequired();

            builder.Property(c => c.TotalPrice).IsRequired();


            // Relations

            //Purchase
            builder.HasOne(o=>o.Purchase)
                    .WithOne(p=>p.Order)
                    .HasForeignKey<Purchase>(p=>p.OrderId)
                    .OnDelete(DeleteBehavior.NoAction);


            // Pharmacy
            builder.HasOne(o => o.pharmacy)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(o => o.PharmacyId)
                   .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
