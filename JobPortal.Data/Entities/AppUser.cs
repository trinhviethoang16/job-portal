using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        //User
        [Display(Name = "Full name")]
        [StringLength(100, ErrorMessage = "Full name cannot be more than 100 characters.")]
        public string? FullName { get; set; }

        [Display(Name = "Phone")]
        [StringLength(12, ErrorMessage = "Too many numbers.", MinimumLength = 9)]
        public string? Phone { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The address cannot be more than 100 characters.")]
        public string? Address { get; set; }

        [Display(Name = "Age")]
        [Range(0, 100, ErrorMessage = "Please enter valid age.")]
        public int? Age { get; set; }

        [Display(Name = "Create date")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The description cannot be more than 256 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Logo")]
        public string? UrlAvatar { get; set; }

        //Employer
        public string? Logo { get; set; }
        public string? City { get; set; }

        [Display(Name = "Contact")]
        [StringLength(256, ErrorMessage = "The contact cannot be more than 256 characters.")]
        public string? Contact { get; set; }

        [Display(Name = "Website")]
        [StringLength(50, ErrorMessage = "The website cannot be more than 50 characters.")]
        public string? WebsiteURL { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }
        public Category? Category { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public int? Status { set; get; } // 0 = denied, 1 = waiting, 2 = confirmed, null = default

        [Required]
        public string Slug { get; set; }
        public Province? Province { get; set; }

        [Display(Name = "Province")]
        public int? ProvinceId { get; set; }
    }
}