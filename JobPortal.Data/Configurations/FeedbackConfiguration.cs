using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.City).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(256);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(12);
            builder.Property(x => x.Status).HasDefaultValue(0);
        }
    }
}