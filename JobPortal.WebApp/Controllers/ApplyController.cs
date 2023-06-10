using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;
using System.Net.NetworkInformation;

namespace JobPortal.WebApp.Controllers
{
    [Route("apply")]
    public class ApplyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataDbContext _context;

        public ApplyController(UserManager<AppUser> userManager, DataDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListApplies(Guid id)
        {
            var CVs = await (from cv in _context.CVs
                             orderby cv.Id descending
                             select new ListCVsViewModel()
                             {
                                 CVId = cv.Id,
                                 Certificate = cv.Certificate,
                                 Major = cv.Major,
                                 ApplyDate = cv.ApplyDate,
                                 GraduatedAt = cv.GraduatedAt,
                                 GPA = cv.GPA,
                                 Description = cv.Description,
                                 ShortDescription = cv.ShortDescription,
                                 Introduce = cv.Introduce,
                                 UserId = cv.UserId,
                                 CVStatus = cv.Status,
                                 Detail = (from d in _context.CVDetails
                                           where cv.Id == d.CVId
                                           select new CVDetailViewModel()
                                           {
                                               CVId = d.CVId,
                                               SkillId = d.SkillId,
                                               Id = d.Id,
                                               Skill = (from skill in _context.Skills
                                                        where d.SkillId == skill.Id
                                                        select skill).FirstOrDefault(),
                                           }).AsEnumerable()
                             }).Where(u => u.UserId == id).ToListAsync();
            return View(CVs);
        }
    }
}