namespace JobPortal.Data.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string? Logo { get; set; }
        public Job? Job { get; set; }
        public int? JobId { get; set; }
        public int? JobPopular { get; set; }
    }
}
