using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.WebsiteURL).HasMaxLength(50);
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Disable).HasDefaultValue(false);
            builder.Property(x => x.Popular).HasDefaultValue(0);
        }
    }
}