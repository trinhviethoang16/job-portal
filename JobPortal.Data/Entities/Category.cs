namespace JobPortal.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<Title>? Titles { get; set; }
        public ICollection<Province>? Provinces { get; set; }
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}
