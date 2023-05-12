using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateBlogViewModel
    {
        [Display(Name = "Tên Blog")]
        public string? Name { get; set; }

        [Display(Name = "Tác giả")]
        public string? Author { get; set; }

        [Display(Name = "Tựa đề")]
        public string? Title { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Mô tả ngắn")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        public IFormFile? ImageUrl { get; set; }
        public Guid UserId { set; get; }
    }
}
