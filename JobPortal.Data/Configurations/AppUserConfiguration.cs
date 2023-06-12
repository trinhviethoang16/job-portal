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
            builder.Property(x => x.Phone).HasMaxLength(12);
            builder.Property(x => x.Address).HasMaxLength(256);
            builder.Property(x => x.Contact).HasMaxLength(256);
            builder.Property(x => x.Location).HasMaxLength(256);
            builder.Property(x => x.SetRole).HasDefaultValue(false);
            builder.Property(x => x.Status).HasDefaultValue(0);
        }
    }
}