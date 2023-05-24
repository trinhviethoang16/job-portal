namespace JobPortal.Data.Entities
{
    public class Time
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? ParentId { set; get; }
        public List<Job> Jobs { get; set; }
    }
}
