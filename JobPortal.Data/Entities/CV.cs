using System.ComponentModel.DataAnnotations;

namespace JobPortal.Data.Entities
{
    public class CV
    {
        public int Id { get; set; }

        [Display(Name = "Certificate")]
        [Required(ErrorMessage = "Please enter your certificate")]
        [StringLength(100, ErrorMessage = "Your certificate cannot be more than 100 characters.")]
        public string Certificate { get; set; }

        [Display(Name = "Major")]
        [Required(ErrorMessage = "Please enter your major")]
        [StringLength(50, ErrorMessage = "Your major cannot be more than 50 characters.")]
        public string Major { get; set; }
        public DateTime ApplyDate { get; set; }

        [Display(Name = "Graduated at")]
        [Required(ErrorMessage = "Please enter where you graduated")]
        [StringLength(50, ErrorMessage = "Your place cannot be more than 50 characters.")]
        public string GraduatedAt { get; set; }

        [Display(Name = "Your GPA")]
        [Required(ErrorMessage = "Please enter your GPA")]
        [Range(0, 4, ErrorMessage = "Please enter valid GPA (0-4).")]
        public float GPA { get; set; }
        public Job? Job { get; set; }

        [Display(Name = "Job")]
        public int JobId { get; set; }
        public Title? Title { get; set; }

        [Display(Name = "Title")]
        public int? TitleId { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter your description")]
        [StringLength(256, ErrorMessage = "Your description cannot be more than 256 characters.")]
        public string Description { get; set; }

        [Display(Name = "Introduce")]
        [Required(ErrorMessage = "Please enter your introduce")]
        [StringLength(100, ErrorMessage = "Your introduce cannot be more than 100 characters.")]
        public string Introduce { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { set; get; }
        public int Status { get; set; } // = 0 denied // = 1 waiting // = 2 accepted // = -1 cancel

        [Display(Name = "Your CV image")]
        public string? UrlImage { get; set; } //CV image

        [Display(Name = "Your phone")]
        [Required(ErrorMessage = "Please enter your phone")]
        [StringLength(12, ErrorMessage = "Please enter valid phonenumber.", MinimumLength = 9)]
        public string Phone { get; set; }

        [Display(Name = "Your email")]
        [Required(ErrorMessage = "Please enter your email")]
        [StringLength(50, ErrorMessage = "Your email cannot be more than 50 characters.")]
        public string Email { get; set; }
    }
}