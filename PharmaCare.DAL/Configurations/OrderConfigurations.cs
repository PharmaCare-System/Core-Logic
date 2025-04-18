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
    public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(p => p.Status)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(p => p.UploadDate)
                   .HasConversion<DateTime>()
                   .IsRequired();
        }
    }
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {


        builder.Property(o => o.OrderType)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(o => o.OrderStatus)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(c => c.DeliveryAddress)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(c => c.TotalPrice).IsRequired();


            // Relations

            // Customer
            builder.HasOne(o=>o.Customer)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CustomerId);

            //Purchase
            builder.HasOne(o=>o.Purchase)
                    .WithOne(p=>p.Order)
                    .HasForeignKey<Purchase>(p=>p.OrderId);

            //M-N with Products
            builder.HasMany(o => o.Products)
                   .WithMany(p => p.Orders)
                   .UsingEntity<ProductOrder>();

            //Pharmacist
            builder.HasOne(o => o.Pharmacist)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(o => o.PharmacistId);

            // Pharmacy
            builder.HasOne(o => o.pharmacy)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(o => o.PharmacyId);

            // Notifications : TODO: it's already done in NotificationConfigurations, so what?
            //builder.HasMany(o => o.Notifications)
            //       .WithOne(n => n.Sender)
            //       .HasForeignKey(o => o.SenderId);
        }
    }
}
