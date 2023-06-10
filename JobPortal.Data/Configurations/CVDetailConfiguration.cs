using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class CVDetailConfiguration : IEntityTypeConfiguration<CVDetail>
    {
        public void Configure(EntityTypeBuilder<CVDetail> builder)
        {
            builder.ToTable("CVDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SkillId).IsRequired();
            builder.Property(x => x.CVId).IsRequired();
        }
    }
}
