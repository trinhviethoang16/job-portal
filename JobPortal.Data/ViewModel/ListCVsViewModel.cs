using JobPortal.Data.Entities;

namespace JobPortal.Data.ViewModel
{
    public class ListCVsViewModel
    {
        public int CVId { get; set; }
        public string Certificate { get; set; }
        public string Major { get; set; }
        public DateTime ApplyDate { get; set; }
        public string GraduatedAt { get; set; }
        public float GPA { get; set; }
        public string Description { get; set; }
        public string Introduce { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int CVStatus { get; set; } // = 0 denied // = 1 waiting // = 2 accepted // = -1 cancel
        public string JobName { get; set; }
        public string EmployerLogo { get; set; }
        public Guid EmployerId { get; set; }
        public string CVImage { get; set; }
		public string CVPhone { get; set; }
		public string CVEmail { get; set; }
	}
}
