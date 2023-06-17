namespace JobPortal.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? ImageUrl { get; set;}
        public Guid? UserId { set; get; }
        public AppUser? AppUser { get; set; }
    }
}