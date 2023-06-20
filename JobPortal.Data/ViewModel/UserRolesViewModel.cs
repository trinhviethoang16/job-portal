using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UserRolesViewModel
    {
        public Guid RoleId { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "The description cannot be more than 256 characters.")]
        public string RoleDescription { get; set; }

        public bool IsSelected { get; set; }
    }
}
