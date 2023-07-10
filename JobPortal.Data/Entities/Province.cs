using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Entities
{
    public class Province
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter province name")]
        [StringLength(50, ErrorMessage = "The province name cannot be more than 50 characters.")]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public Category? Category { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public bool? Disable { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public int Popular { get; set; }
    }
}