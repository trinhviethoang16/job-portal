namespace JobPortal.Data.Entities
{
    public class Time
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool? Disable { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}