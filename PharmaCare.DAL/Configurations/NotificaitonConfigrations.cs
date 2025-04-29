using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Configurations
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
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


            builder.Property(n => n.UserType)
                .IsRequired()
                .HasConversion<string>() 
                .HasMaxLength(20).IsRequired();

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500).IsRequired();

            builder.Property(n => n.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(n => n.IsRead)
                .IsRequired();

            //relation
            builder
               .HasDiscriminator<UserType>(nameof(Notification.UserType))
               .HasValue<CustomerNotification>(UserType.Customer)
               .HasValue<PharmacyNotification>(UserType.Pharmacy);
        }
    }

}
