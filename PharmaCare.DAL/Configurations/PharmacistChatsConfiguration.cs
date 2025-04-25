using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Configurations
{
    public class PharmacistChatsConfiguration : IEntityTypeConfiguration<PharmacistChats>
    {
        public void Configure(EntityTypeBuilder<PharmacistChats> builder)
        {

            builder.HasKey(pc => new { pc.PharmacistId, pc.ChatId });
        }
    }
}
