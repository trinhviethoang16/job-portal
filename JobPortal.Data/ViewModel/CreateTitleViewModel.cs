using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateTitleViewModel
    {
        [Required(ErrorMessage = "Please enter title name")]
        [StringLength(100, ErrorMessage = "The title name cannot be more than 100 characters.")]
        public string Name { get; set; }
    }
}
