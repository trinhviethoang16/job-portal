using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateEmployerViewModel
    {
        [Display(Name = "Full name")]
        [StringLength(100, ErrorMessage = "Full name cannot be more than 100 characters.")]
        public string? FullName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Contact")]
        public string? Contact { get; set; }

        [Display(Name = "Logo")]
        public IFormFile? UrlAvatar { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "Website")]
        [StringLength(50, ErrorMessage = "The website cannot be more than 50 characters.")]
        public string? WebsiteURL { get; set; }

        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
    }
}
