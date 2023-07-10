using JobPortal.Common;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateJobViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter product name.")]
        [StringLength(100, ErrorMessage = "Job name cannot be more than 100 characters.")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Introduce")]
        public string? Introduce { get; set; }
        [Display(Name = "Object target")]
        public string? ObjectTarget { get; set; }
        [Display(Name = "Work experience")]
        public string? Experience { get; set; }
        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        [Display(Name = "Working type")]
        public int TimeId { get; set; }
        [Display(Name = "Min salary")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid salary.")]
        public int? MinSalary { get; set; }
        [Display(Name = "Max salary")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid salary.")]
        //[SalaryRange("MinSalary")] //Salary Range Validation Attribute
        public int? MaxSalary { get; set; }
        [Display(Name = "Skills")]
        public List<int> SkillIds { get; set; }
        [Display(Name = "Title")]
        public int TitleId { get; set; }
    }
}