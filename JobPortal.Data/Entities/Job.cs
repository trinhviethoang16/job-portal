using System.ComponentModel.DataAnnotations;
using JobPortal.Common;

namespace JobPortal.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter product name.")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public Category? Category { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Title? Title { get; set; }
        [Display(Name = "Title")]
        public int TitleId { get; set; }
        public string? Description { get; set; }
        public string? Introduce { get; set; }
        [Display(Name = "Object target")]
        public string? ObjectTarget { get; set; }
        [Display(Name = "Work experience")]
        public string? Experience { get; set; }
        public DateTime? CreateDate { get; set; }
        [Display(Name = "Min age")]
        [Range(0, 100)]
        public byte? MinAge { get; set; }
        [Display(Name = "Max age")]
        [Range(1, 100)]
        [AgeRange("MinAge")] //Age Range Validation Attribute
        public byte? MaxAge { get; set; }
        public int? Popular { get; set; }
        public Province? Province { get; set; }
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        public Time? Time { get; set; }
        [Display(Name = "Working type")]
        public int TimeId { get; set; }
        [Required(ErrorMessage = "Please enter min salary.")]
        [Display(Name = "Min salary")]
        public int? MinSalary { get; set; }
        [Required(ErrorMessage = "Please enter max salary.")]
        [Display(Name = "Max salary")]
        [SalaryRange("MinSalary")]
        public int? MaxSalary { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public Skill? Skill { get; set; }
        [Display(Name = "Skill")]
        public int SkillId { get; set; }
    }
}
