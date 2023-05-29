namespace JobPortal.Data.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public int? ParentID { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}
