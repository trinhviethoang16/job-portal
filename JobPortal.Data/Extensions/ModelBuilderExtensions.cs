using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            //var employerId = new Guid("15BD226F-8514-93B1-B1B5-F12668BE58DC");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role"
            },
            new AppRole
            {
                Id = new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                Name = "Employer",
                NormalizedName = "EMPLOYER",
                Description = "Emloyer role"
            },
            new AppRole
            {
                Id = new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                Name = "User",
                NormalizedName = "USER",
                Description = "User role"
            });

            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc123!@#"),
                SecurityStamp = string.Empty,
                FullName = "Adminitrator",
                RoleName = "Admin"
            });
            //new AppUser
            //{
            //    Id = employerId,
            //    UserName = "employer@gmail.com",
            //    NormalizedUserName = "EMPLOYER@GMAIL.COM",
            //    Email = "employer@gmail.com",
            //    NormalizedEmail = "EMPLOYER@GMAIL.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "Abc123!"),
            //    SecurityStamp = string.Empty,
            //    FullName = "Employer"
            //});

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Category>().HasData(
               new Category() { Id = 1, Name = "Skill", Slug = "skill", Description = "Skill ne" },
               new Category() { Id = 2, Name = "Title", Slug = "title", Description = "Title ne" },
               new Category() { Id = 3, Name = "Employer", Slug = "employer", Description = "Employer ne" },
               new Category() { Id = 4, Name = "Province", Slug = "province", Description = "Province ne" }
            );

            modelBuilder.Entity<Time>().HasData(
               new Time() { Id = 1, Name = "Part time" },
               new Time() { Id = 2, Name = "Full time" },
               new Time() { Id = 3, Name = "Work form home" }
            );
        }
    }
}
