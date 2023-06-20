using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateBlogViewModel
    {
        [Display(Name = "Blog")]
        public string? Name { get; set; }

        [Display(Name = "Author")]
        public string? Author { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Descriprion")]
        public string? Description { get; set; }

        [Display(Name = "Introduce")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }
        public Guid UserId { set; get; }
    }
}
