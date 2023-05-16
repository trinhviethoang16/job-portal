using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        public string Description { get; set; }
    }
}
