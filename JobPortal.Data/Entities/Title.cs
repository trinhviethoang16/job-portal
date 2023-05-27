namespace JobPortal.Data.Entities
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
