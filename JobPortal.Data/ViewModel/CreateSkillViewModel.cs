using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateSkillViewModel
    {
        public string Name { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
