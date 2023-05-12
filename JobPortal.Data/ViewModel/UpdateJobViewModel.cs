using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateJobViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Workplace { get; set; }
        public byte? MinAge { get; set; }
        public byte? MaxAge { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public IFormFile? ImageURL { get; set; }
    }
}
