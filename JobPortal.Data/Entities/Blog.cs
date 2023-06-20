using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }
        public string? Slug { get; set; }

        [Display(Name = "Author")]
        [StringLength(100, ErrorMessage = "The author cannot be more than 100 characters.")]
        public string? Author { get; set; }

        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "The author cannot be more than 200 characters.")]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Introduce")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Image")]
        public string? Image { get; set; }
        public Guid? UserId { set; get; }
        public AppUser? AppUser { get; set; }
    }
}