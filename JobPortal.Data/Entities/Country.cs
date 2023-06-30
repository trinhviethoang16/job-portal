namespace JobPortal.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public bool? Disable { get; set; }
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}