using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateUserViewModel
    {
		public IFormFile? Image { get; set; }
		public string? Introduce { get; set; }
		public string? Description { get; set; }
		public string? ShortDescription { get; set; }
	}
}
