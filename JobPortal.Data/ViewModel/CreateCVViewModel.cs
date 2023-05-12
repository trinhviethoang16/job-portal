using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateCVViewModel
    {
        public string? Certificate { get; set; }
        public string? Major { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string? GraduatedAt { get; set; }
        public float? GPA { get; set; }
        public string? CurrentJob { get; set; }
        public string? TitleName { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Introduce { get; set; }
        public Guid? UserId { set; get; }
    }
}
