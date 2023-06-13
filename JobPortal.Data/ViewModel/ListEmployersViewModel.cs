using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class ListEmployersViewWModel
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public string? Description { get; set; }
        public string? Contact { get; set; }
        public string? UrlAvatar { get; set; }
        public string? Location { get; set; }
        public string? WebsiteURL { get; set; }
        public int? Status { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? ProvinceName { get; set; }
    }
}
