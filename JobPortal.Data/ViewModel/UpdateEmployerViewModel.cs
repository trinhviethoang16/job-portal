using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateEmployerViewModel
    {
        [Display(Name = "Full name")]
        public string? FullName { get; set; }

        public string? Description { get; set; }
        public string? Contact { get; set; }

        [Display(Name = "Logo")]
        public IFormFile? UrlAvatar { get; set; }
        public string? Location { get; set; }
        public string? WebsiteURL { get; set; }
        public int? Status { get; set; } // 0 = denied, 1 = waiting, 2 = confirmed
        public int ProvinceId { get; set; }
    }
}
