using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateBlogViewModel
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public Guid UserId { set; get; }
    }
}
