using JobPortal.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class ListCVsViewModel
    {
        public int CVId { get; set; }

        [Display(Name = "Certificate")]
        public string Certificate { get; set; }

        [Display(Name = "Major")]
        public string Major { get; set; }

        [Display(Name = "Apply date")]
        public DateTime ApplyDate { get; set; }

        [Display(Name = "Graduated at")]
        public string GraduatedAt { get; set; }

        [Display(Name = "GPA")]
        public float GPA { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Introduce")]
        public string Introduce { get; set; }
        public Guid UserId { get; set; }

        [Display(Name = "Applicant name")]
        public string UserName { get; set; }
        public int CVStatus { get; set; } // = 0 denied // = 1 waiting // = 2 accepted // = -1 cancel

        [Display(Name = "Job name")]
        public string JobName { get; set; }

        [Display(Name = "Logo")]
        public string EmployerLogo { get; set; }

        public Guid EmployerId { get; set; }

        [Display(Name = "CV")]
        public string CVImage { get; set; }

        [Display(Name = "Phone")]
        public string CVPhone { get; set; }

        [Display(Name = "Email")]
        public string CVEmail { get; set; }
	}
}
