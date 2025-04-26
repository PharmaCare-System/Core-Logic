using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(c=>c.Id);
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
