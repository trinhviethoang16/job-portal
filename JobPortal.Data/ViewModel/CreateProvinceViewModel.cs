using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateProvinceViewModel
    {
        public string Name { get; set; }
        public string? Slug { get; set; }
    }
}
