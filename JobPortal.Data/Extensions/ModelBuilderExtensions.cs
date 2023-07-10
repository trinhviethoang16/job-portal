using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //For Admin role
            var adminRoleId = new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8");

            //For Admin default account
            var adminId = new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role"
            },
            new AppRole
            {
                Id = new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                Name = "Employer",
                NormalizedName = "EMPLOYER",
                Description = "Employer role"
            },
            new AppRole
            {
                Id = new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
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
                Slug = "adminitrator",
                UrlAvatar = "default_admin.png",
                Disable = false,
                CreateDate = DateTime.Now,
                Status = -1 //admin status
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });

            modelBuilder.Entity<Category>().HasData(
               new Category() { Id = 1, Name = "Skill", Slug = "skill", Description = "the ability to carry out diverse duties in IT roles" },
               new Category() { Id = 2, Name = "Title", Slug = "title", Description = "the type of position and level an employee holds" },
               new Category() { Id = 3, Name = "Employer", Slug = "employer", Description = "seek candidates who write code in several coding languages" },
               new Category() { Id = 4, Name = "Province", Slug = "province", Description = "where an Employee reports for work at Company" }
            );

            modelBuilder.Entity<Time>().HasData(
               new Time() { Id = 1, Name = "Part time", Slug = "part-time" },
               new Time() { Id = 2, Name = "Full time", Slug = "full-time" },
               new Time() { Id = 3, Name = "Work from home", Slug = "work-from-home" },
               new Time() { Id = 4, Name = "At office", Slug = "at-office" },
               new Time() { Id = 5, Name = "Temporary", Slug = "temporary" }
            );

            modelBuilder.Entity<Province>().HasData(
               new Province() { Id = 1, Name = "Ho Chi Minh", Slug = "ho-chi-minh", CategoryId = 4 },
               new Province() { Id = 2, Name = "Ha Noi", Slug = "ha-noi", CategoryId = 4 },
               new Province() { Id = 3, Name = "Da Nang", Slug = "da-nang", CategoryId = 4 },
               new Province() { Id = 4, Name = "Others", Slug = "others", CategoryId = 4 }
            );

            modelBuilder.Entity<Country>().HasData(
               new Country() { Id = 1, Name = "Vietnam", Flag = "Vietnam.png" },
               new Country() { Id = 2, Name = "United States", Flag = "USA.png" },
               new Country() { Id = 3, Name = "China", Flag = "China.png" },
               new Country() { Id = 4, Name = "Japan", Flag = "Japan.png" },
               new Country() { Id = 5, Name = "Singapore", Flag = "Singapore.png" },
               new Country() { Id = 6, Name = "Canada", Flag = "Canada.png" },
               new Country() { Id = 7, Name = "England", Flag = "England.png" },
               new Country() { Id = 8, Name = "India", Flag = "India.png" },
               new Country() { Id = 9, Name = "Russia", Flag = "Russia.png" },
               new Country() { Id = 10, Name = "Switzerland", Flag = "Switzerland.png" },
               new Country() { Id = 11, Name = "France", Flag = "France.png" },
               new Country() { Id = 12, Name = "Italy", Flag = "Italy.png" },
               new Country() { Id = 13, Name = "Poland", Flag = "Poland.png" },
               new Country() { Id = 14, Name = "South Korea", Flag = "Korea.png" },
               new Country() { Id = 15, Name = "Australia", Flag = "Australia.png" },
               new Country() { Id = 16, Name = "Germany", Flag = "Germany.png" },
               new Country() { Id = 17, Name = "Sweden", Flag = "Sweden.png" }
            );
        }
    }
}