using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasOne(c => c.Pharmacy)
                   .WithMany(ph => ph.Chats)
                   .HasForeignKey(c => c.PharmacyId);

            builder.HasMany(c => c.Messages)
                   .WithOne(m => m.Chat)
                   .HasForeignKey(m => m.ChatId);

            // pharmacist Access Chat (N to N):
            builder.HasMany(p => p.pharmacists)
                   .WithMany(c => c.Chats)
                   .UsingEntity<PharmacistChats>(
                        pp => pp.HasOne(pc => pc.Pharmacist)
                                .WithMany(p => p.PharmacistChats)
                                .OnDelete(DeleteBehavior.Cascade),

                        oo => oo.HasOne(po => po.Chat)
                                .WithMany(p => p.pharmacistChats)
                                .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
