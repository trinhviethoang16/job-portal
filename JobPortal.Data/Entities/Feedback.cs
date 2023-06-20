using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        [Display(Name = "Address")]
        [StringLength(256, ErrorMessage = "The address cannot be more than 256 characters.")]
        public string? Address { get; set; }

        [Display(Name = "Your phone")]
        [StringLength(12, ErrorMessage = "Too many numbers.", MinimumLength = 9)]
        public string? Phone { get; set; }

        [Display(Name = "Description")]
        [StringLength(256, ErrorMessage = "Description cannot be more than 256 characters.")]
        public string? Description { get; set; }

        [Display(Name = "Comment")]
        public string? Comment { get; set; }

        [Display(Name = "Rating")]
        [Range(0, 10, ErrorMessage = "Please enter valid rating (0-10).")]
        public byte? Rating { get; set; }
        public DateTime? CommentOn { get; set; }

        [Display(Name = "City")]
        [StringLength(30, ErrorMessage = "The city cannot be more than 30 characters.")]
        public string? City { get; set; }

        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "The email cannot be more than 50 characters.")]
        public string? Email { get; set; }
        public Job? Job { get; set; }

        [Display(Name = "Job")]
        public int JobId { get; set; }
        public int Status { get; set; } // admin: 0 = default value, 1 = view feedback (already feedback) //user: 0 = not created yet, 1 = view feedback
    }
}