using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tên đầy đủ")]
        [StringLength(100, ErrorMessage = "Không thể quá 100 kí tự.")]
        public string? FullName { get; set; }

        [Display(Name = "Tuổi")]
        [Range(0, 150)]
        public int? Age { get; set; }

        [Display(Name = "Số điện thoại")]
		[StringLength(12, ErrorMessage = "Quá nhiều kí tự.", MinimumLength = 9)]
		public string? Phone { get; set; }

		[Display(Name = "Địa chỉ")]
		[StringLength(200, ErrorMessage = "Địa chỉ không thể quá 200 kí tự.")]
		public string? Address { get; set; }


        //Role
		//public bool? SetRole { get; set; } //0 is User, 1 is Employer
		//public bool? IsAdmin { get; set; } //0 for default value, 1 only for Admin account
	}
}
