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
        public int JobId { get; set; }
        public Title? Title { get; set; }
        public int? TitleId { get; set; }
        public string Description { get; set; }
        public string Introduce { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { set; get; }
        public int Status { get; set; } // = 0 denied // = 1 waiting // = 2 accepted // = -1 cancel
        public string? UrlImage { get; set; } //CV image
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
