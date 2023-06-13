using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using System;
using JobPortal.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/apply")]
    public class ApplyController : Controller
    {
        private readonly DataDbContext _context;

        public ApplyController(DataDbContext context)
        {
            _context = context;
        }

        [Route("{id}/{status}")]
        public async Task<IActionResult> Index(Guid id, int status)
        {
            var CV = (from cv in _context.CVs
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
                            Introduce = cv.Introduce,
                            UserId = cv.AppUserId,
                            CVStatus = cv.Status,
                            JobName = cv.Job.Name,
                            EmployerLogo = cv.Job.AppUser.UrlAvatar,
                            UserName = cv.Job.AppUser.FullName,
                            CVImage = cv.UrlImage,
                            CVPhone = cv.Phone,
                            CVEmail = cv.Email,
                            EmployerId = cv.Job.AppUser.Id,
                        }).Where(cv => cv.EmployerId == id);
            var CVs = await CV.ToListAsync();
            switch (status)
            {
                case 0: // denied
                    CVs = await CV.Where(cv => cv.CVStatus == 0).ToListAsync();
                    break;
                case 1: // waiting
                    CVs = await CV.Where(cv => cv.CVStatus == 1).ToListAsync();
                    break;
                case 2: // accepted
                    CVs = await CV.Where(cv => cv.CVStatus == 2).ToListAsync();
                    break;
                case 3: // all but cancel status
                    CVs = await CV.Where(cv => cv.CVStatus != -1).ToListAsync();
                    break;
                default:
                    CVs = await CV.Where(cv => cv.CVStatus != -1).ToListAsync();
                    break;
            }
            return View(CVs);
        }

        [Route("update-cv-status/{id}/{CVId}/{status}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCVStatus(Guid id, int CVId, int status)
        {
            var CV = await _context.CVs.FirstOrDefaultAsync(CV => CV.Id == CVId);
            CV.Status = status;
            _context.CVs.Update(CV);
            await _context.SaveChangesAsync();
            return Redirect("/employer/apply/" + id + "/" + status);
        }

        [Route("{id}/{CVId}/feedback")]
        public async Task<IActionResult> Feedback(Guid id, int CVId)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == id);
            var CV = await _context.CVs.FirstOrDefaultAsync(CV => CV.Id == CVId);
            return View();
        }
    }
}