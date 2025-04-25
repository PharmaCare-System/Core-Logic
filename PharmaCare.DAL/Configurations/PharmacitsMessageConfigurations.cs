using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Configurations
{
    public class PharmacitsMessageConfigurations : IEntityTypeConfiguration<MessagesPharmacist>
    {
        public void Configure(EntityTypeBuilder<MessagesPharmacist> builder)
        {
            builder.HasOne(mc => mc.Pharmacist)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.UserId);
        }
    }
}
