using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateEmployerViewModel
    {
        [EmailAddress]
        [Display(Name = "Email account login")]
        public string? Email { get; set; }
        [Display(Name = "Company name")]
        [StringLength(100, ErrorMessage = "Company name cannot be more than 100 characters.")]
        public string? FullName { get; set; }
        [Display(Name = "Company overview")]
        public string? Description { get; set; }
        [Display(Name = "Company contact")]
        public string? Contact { get; set; }
        [Display(Name = "Logo")]
        public IFormFile? UrlAvatar { get; set; }
        [Display(Name = "Location")]
        public string? Location { get; set; }
        [Display(Name = "Company website")]
        [StringLength(50, ErrorMessage = "The website cannot be more than 50 characters.")]
        public string? WebsiteURL { get; set; }
        [Display(Name = "Company province")]
        public int ProvinceId { get; set; }
        [Display(Name = "Company size")]
        public string? CompanySize { get; set; }
        [Display(Name = "Working days")]
        public string? WorkingDays { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Contact number")]
        [StringLength(20, ErrorMessage = "Please enter valid contact number.", MinimumLength = 9)]
        public string? Phone { get; set; }
        [Display(Name = "Content")]
        public string? Content { get; set; }
    }
}
