using System.ComponentModel.DataAnnotations;
using JobPortal.Common;

namespace JobPortal.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter product name.")]
        [StringLength(100, ErrorMessage = "Job name cannot be more than 100 characters.")]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public Category? Category { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Title? Title { get; set; }
        [Display(Name = "Title")]
        public int TitleId { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Introduce")]
        public string? Introduce { get; set; }
        [Display(Name = "Object target")]
        public string? ObjectTarget { get; set; }
        [Display(Name = "Work experience")]
        public string? Experience { get; set; }
        [Display(Name = "Create date")]
        public DateTime? CreateDate { get; set; }
        public int Popular { get; set; }
        public Province? Province { get; set; }
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        public Time? Time { get; set; }
        [Display(Name = "Working type")]
        public int TimeId { get; set; }
        [Display(Name = "Min salary")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid salary.")]
        public int? MinSalary { get; set; }
        [Display(Name = "Max salary")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid salary.")]
        //[SalaryRange("MinSalary")] //Salary Range Validation Attribute
        public int? MaxSalary { get; set; }
        public AppUser? AppUser { get; set; }
        [Display(Name = "Employer")]
        public Guid AppUserId { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public ICollection<CV>? CVs { get; set; }
    }
}