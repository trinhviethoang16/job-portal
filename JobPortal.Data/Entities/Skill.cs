namespace JobPortal.Data.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public string? Logo { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public virtual ICollection<Job>? Jobs { get; set; }
        //CV - Skill
        public List<CVDetail> CVDetails { get; set; }
    }
}
