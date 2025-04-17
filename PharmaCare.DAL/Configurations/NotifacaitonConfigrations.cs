using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class NotifacaitonConfigrations : IEntityTypeConfiguration<Notifacation>
    {
        public void Configure(EntityTypeBuilder<Notifacation> builder)
        {

            builder.HasKey(n => n.Id);

        
            builder.Property(n => n.Sender)
                .IsRequired()
                .HasConversion<string>() 
                .HasMaxLength(20);

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(n => n.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(n => n.IsRead)
                .IsRequired()
                .HasDefaultValue(false);
            builder.HasOne(p => p.Inventory).WithMany(p=>p.notifacations)
                .HasForeignKey(n => n.SenderId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.order)
                .WithMany(p => p.notifacations) 
                .HasForeignKey(n => n.OrderId)
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.SetNull);

            builder
       .HasDiscriminator<SenderType>(nameof(Notifacation.Sender))
       .HasValue<OrderNotification>(SenderType.order)
       .HasValue<MessageNotification>(SenderType.message);

        }
    }
}
