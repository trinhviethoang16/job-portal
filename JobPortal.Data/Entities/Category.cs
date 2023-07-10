using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter category name")]
        [StringLength(100, ErrorMessage = "Category name cannot be more than 100 characters.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The description cannot be more than 256 characters.")]
        public string? Description { get; set; }
        [Required]
        public string Slug { get; set; }
        public bool? Disable { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<Title>? Titles { get; set; }
        public ICollection<Province>? Provinces { get; set; }
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}