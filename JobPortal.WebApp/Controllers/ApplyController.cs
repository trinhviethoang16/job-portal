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

        [Route("{slug}/{id}")]
        public async Task<IActionResult> Apply(string slug, Guid id)
        {
            var job = await _context.Jobs.Where(j => j.Slug == slug).FirstAsync();
            var user = await _context.AppUsers.Where(u => u.Id == id).FirstAsync();
            var cv = await _context.CVs.Where(x => x.UserId == id).Where(x => x.JobId == job.Id).FirstAsync();
            // check role
            if (!User.IsInRole("User"))
            {
                return RedirectToAction(nameof(AccessDenied));
            }
            // check đã nộp cv ở job đó hay chưa
            else if (cv.Status == 1)
            {
                return RedirectToAction(nameof(Waiting));
            }
            else
            {
                return View(user);
            }
        }

        [Route("{slug}/{id}")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Apply(string slug, Guid id, CreateCVViewModel model)
        {
            var job = await _context.Jobs.Where(j => j.Slug == slug).FirstAsync();

            CV cv = new CV()
            {
                ApplyDate = DateTime.Now,
                Certificate = model.Certificate,
                GraduatedAt = model.GraduatedAt,
                GPA = model.GPA,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                Introduce = model.Introduce,
                UserId = id,
                JobId = job.Id,
                Status = 1
            };
            _context.CVs.Add(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListApplies");
        }

        [Route("access-denied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

        [Route("fail")]
        public IActionResult Fail()
        {
            return View();
        }

        [Route("waiting")]
        public IActionResult Waiting()
        {
            return View();
        }
    }
}