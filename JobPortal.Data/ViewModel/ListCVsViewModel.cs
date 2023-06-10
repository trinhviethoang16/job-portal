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
        public string ShortDescription { get; set; }
        public string Introduce { get; set; }
        public IEnumerable<CVDetailViewModel> Detail { get; set; }
        public Guid UserId { set; get; }
        public int CVStatus { get; set; } // = 0 all apply job // = 1 waiting // = 2 accepted // = 3 denied
    }

    public class CVDetailViewModel
    {
        public int Id { get; set; }
        public int CVId { get; set; }
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
    }
}
