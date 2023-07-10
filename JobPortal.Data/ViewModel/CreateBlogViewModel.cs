using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateBlogViewModel
    {
        [Display(Name = "Author")]
        [StringLength(50, ErrorMessage = "The author cannot be more than 100 characters.")]
        [Required(ErrorMessage = "Please enter author name.")]
        public string Author { get; set; }
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "The title cannot be more than 100 characters.")]
        [Required(ErrorMessage = "Please enter title of blog.")]
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string? Content { get; set; }
        [Display(Name = "Image")]
        public IFormFile? Image { get; set; }
        [Display(Name = "Blog overview")]
        public string? Description { get; set; }
    }
}