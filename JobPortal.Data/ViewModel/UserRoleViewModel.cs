using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UserRoleViewModel
    {
        public Guid UserId { get; set; }
        [Display(Name = "Name")]
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
