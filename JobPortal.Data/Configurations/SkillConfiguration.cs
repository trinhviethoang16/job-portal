using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Logo).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Disable).HasDefaultValue(false);
            builder.Property(x => x.CategoryId).HasDefaultValue(1);
            builder.Property(x => x.Popular).HasDefaultValue(0);
        }
    }
}