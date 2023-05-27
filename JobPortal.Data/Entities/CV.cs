namespace JobPortal.Data.Entities
{
    public class CV
    {
        public int Id { get; set; }
        public string? Certificate { get; set; }
        public string? Major { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string? GraduatedAt { get; set; }
        public float? GPA { get; set; }
        public Job? Job { get; set; }
        public int? JobId { get; set; }
        public string? CurrentJob { get; set; }
        public Title? Title { get; set; }
        public int? TitleId { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Introduce { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public string? SkillName { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid? UserId { set; get; }
    }
}
