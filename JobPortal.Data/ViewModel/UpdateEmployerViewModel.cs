using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateEmployerViewModel
    {
		public IFormFile? Logo { get; set; }
		public string? City { get; set; }
		public string? Contact { get; set; }
		public string? WebsiteURL { get; set; }
		public string? Location { get; set; }
	}
}
