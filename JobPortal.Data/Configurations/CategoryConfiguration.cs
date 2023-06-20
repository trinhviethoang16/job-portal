using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256);
            builder.Property(x => x.Disable).HasDefaultValue(false);
            builder.Property(x => x.Slug).IsRequired();
        }
    }
}