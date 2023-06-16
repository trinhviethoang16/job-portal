using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
