using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateFeedbackViewModel
    {
        public Guid AppUserId { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
        public byte? Rating { get; set; }
        public DateTime? CommentOn { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public int JobId { get; set; }
    }
}
