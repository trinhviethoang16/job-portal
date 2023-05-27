namespace JobPortal.Data.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public int? ParentID { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
