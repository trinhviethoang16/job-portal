using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateSkillViewModel
    {
        [Required(ErrorMessage = "Please enter skill name")]
        [StringLength(50, ErrorMessage = "The skill name cannot be more than 50 characters.")]
        public string Name { get; set; }
        [Display(Name = "Skill logo")]
        [Required(ErrorMessage = "Please enter skill logo")]
        public IFormFile Logo { get; set; }
    }
}
