using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Entities
{
    public class Title
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}
