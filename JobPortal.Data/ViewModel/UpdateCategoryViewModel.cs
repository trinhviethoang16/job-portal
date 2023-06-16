using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class UpdateCategoryViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
