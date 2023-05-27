namespace JobPortal.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public Title? Title { get; set; }
        public int? TitleId { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte? MinAge { get; set; }
        public byte? MaxAge { get; set; }
        public DateTime? FirstApplyDate { get; set; }
        public DateTime? LastApplyDate { get; set; }
        public int? Popular { get; set; }
        public Province? Province { get; set; }
        public int? ProvinceId { get; set; }
        public string? ProvinceName { get; set; }
        public Time? Time { get; set; }
        public int? TimeId { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public string? ImageURL { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid? UserId { get; set; }
    }
}
