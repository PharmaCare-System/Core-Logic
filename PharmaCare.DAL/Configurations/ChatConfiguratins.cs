using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
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


            builder.HasOne(c => c.Pharmacy)
                   .WithMany(ph => ph.Chats)
                   .HasForeignKey(c => c.PharmacyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Messages)
                   .WithOne(m => m.Chat)
                   .HasForeignKey(m => m.ChatId)
                   .OnDelete(DeleteBehavior.Cascade);

            // pharmacist Access Chat (N to N):
            builder.HasMany(p => p.pharmacists)
                   .WithMany(c => c.Chats)
                   .UsingEntity<PharmacistChats>(
                        pp => pp.HasOne(pc => pc.Pharmacist)
                                .WithMany(p => p.PharmacistChats)
                                .HasForeignKey(pc => pc.PharmacistId)
                                .OnDelete(DeleteBehavior.Cascade),

                        oo => oo.HasOne(po => po.Chat)
                                .WithMany(p => p.pharmacistChats)
                                .HasForeignKey(po => po.ChatId)
                                .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
