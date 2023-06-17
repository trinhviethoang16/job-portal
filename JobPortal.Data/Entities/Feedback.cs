namespace JobPortal.Data.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
        public byte? Rating { get; set; }
        public DateTime? CommentOn { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public Job? Job { get; set; }
        public int JobId { get; set; }
        // admin: 0 = default value, 1 = view feedback (already feedback) //user: 0 = not created yet, 1 = view feedback
        public int Status { get; set; }
    }
}