using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Data.Configurations
{
    public class CVConfiguration : IEntityTypeConfiguration<CV>
    {
        public void Configure(EntityTypeBuilder<CV> builder)
        {
            builder.ToTable("CVs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Certificate).HasMaxLength(100);
            builder.Property(x => x.Major).HasMaxLength(50);
			builder.Property(x => x.GraduatedAt).HasMaxLength(50);
			builder.Property(x => x.Phone).HasMaxLength(12);
			builder.Property(x => x.Email).HasMaxLength(50);
		}
    }
}