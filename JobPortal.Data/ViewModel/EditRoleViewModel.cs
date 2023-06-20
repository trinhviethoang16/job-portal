using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
