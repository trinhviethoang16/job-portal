using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class ListEmployersViewWModel
    {
        public Guid? Id { get; set; }
        [Display(Name = "Full name")]
        public string? FullName { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Contact")]
        public string? Contact { get; set; }
        [Display(Name = "Logo")]
        public string? UrlAvatar { get; set; }
        [Display(Name = "Location")]
        public string? Location { get; set; }
        [Display(Name = "Website")]
        public string? WebsiteURL { get; set; }
        public int? Status { get; set; }
        [Display(Name = "Register date")]
        public DateTime? RegisterDate { get; set; }
        [Display(Name = "Province")]
        public string? ProvinceName { get; set; }
    }
}
