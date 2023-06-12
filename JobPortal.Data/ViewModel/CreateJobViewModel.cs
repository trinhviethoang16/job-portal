using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Data.ViewModel
{
    public class CreateJobViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Introduce { get; set; }
        public string? ObjectTarget { get; set; }
        public string? Experience { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte? MinAge { get; set; }
        public byte? MaxAge { get; set; }
        public int ProvinceId { get; set; }
        public int TimeId { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }
        public int SkillId { get; set; }
        public int TitleId { get; set; }
    }
}
