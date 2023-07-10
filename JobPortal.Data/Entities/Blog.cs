using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Author")]
        [StringLength(50, ErrorMessage = "The author cannot be more than 100 characters.")]
        [Required(ErrorMessage = "Please enter author name.")]
        public string Author { get; set; }
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "The title cannot be more than 100 characters.")]
        [Required(ErrorMessage = "Please enter title of blog.")]
        public string Title { get; set; }
        [Display(Name = "Content")]
        [Required(ErrorMessage = "Please enter content of blog.")]
        public string Content { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter image of blog")]
        public string Image { get; set; }
        public Guid? AppUserId { set; get; }
        public AppUser? AppUser { get; set; }
        public DateTime CreateDate { set; get; }
        [Display(Name = "Blog overview")]
        public string? Description { get; set; }
        public int Popular { get; set; }
    }
}