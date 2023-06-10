namespace JobPortal.Data.Entities
{
    public class CV
    {
        public int Id { get; set; }
        public string Certificate { get; set; }
        public string Major { get; set; }
        public DateTime ApplyDate { get; set; }
        public string GraduatedAt { get; set; }
        public float GPA { get; set; }
        public Job? Job { get; set; }
        public int? JobId { get; set; }
        public Title? Title { get; set; }
        public int? TitleId { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Introduce { get; set; }
        //CV - Skill
        public List<CVDetail> CVDetails { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid UserId { set; get; }
        public int Status { get; set; } // = 0 all apply job // = 1 waiting // = 2 accepted // = 3 denied
    }
}
