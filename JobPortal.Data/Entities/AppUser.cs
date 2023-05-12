using Microsoft.AspNetCore.Identity;

namespace JobPortal.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        //User
        public string? FullName { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Introduce { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? UrlAvatar { get; set; }

        //Employer
        public string? Logo { get; set; }
        public string? City { get; set; }
        public string? Contact { get; set; }
        public string? WebsiteURL { get; set; }
        public string? Location { get; set; }

        //Role
        public bool? SetRole { get; set; } //0 is User, 1 is Employer
    }
}
