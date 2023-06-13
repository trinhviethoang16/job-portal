using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateCVViewModel
    {
        public string Certificate { get; set; }
        public string Major { get; set; }
        public string GraduatedAt { get; set; }
        public float GPA { get; set; }
        public string Description { get; set; }
        public string Introduce { get; set; }
        public Guid UserId { set; get; }
        public int Status { get; set; } // = 0 all apply job // = 1 waiting // = 2 accepted // = 3 denied
        public IFormFile UrlImage { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
