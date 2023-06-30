    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/job")]
    [Authorize(Roles = "Employer")]
    public class JobController : Controller
    {
        private readonly DataDbContext _context;

        public JobController(DataDbContext context)
        {
            _context = context;
        }

        [Route("{id}")]
        public async Task<IActionResult> Index(Guid id, int? page)
        {
            int pageSize = 5; //number of jobs per page

            var jobs = await _context.Jobs
                .Where(j => j.AppUserId == id)
                .Include(j => j.AppUser)
                .Include(j => j.Province)
                .Include(j => j.Time)
                .Include(j => j.Skill)
                .Include(j => j.Title)
                .OrderByDescending(j => j.Id)
                .ToListAsync();
            return View(jobs.ToPagedList(page ?? 1, pageSize));
        }

        [Route("{id}/create")]
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces.OrderBy(p => p.Id), "Id", "Name");
            ViewData["TimeId"] = new SelectList(_context.Times.OrderBy(t => t.Id), "Id", "Name");
            ViewData["SkillId"] = new SelectList(_context.Skills.OrderBy(s => s.Name), "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Titles.OrderBy(t => t.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("{id}/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, CreateJobViewModel model)
        {
            var user = await _context.AppUsers.Where(u => u.Id == id).FirstAsync();
            if (ModelState.IsValid)
            {
                Job job = new Job()
                {
                    Name = model.Name,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower(),
                    CreateDate = DateTime.Now,
                    Description = model.Description,
                    Introduce = model.Introduce,
                    ObjectTarget = model.ObjectTarget,
                    Experience = model.Experience,
                    MinAge = model.MinAge,
                    MaxAge = model.MaxAge,
                    MinSalary = model.MinSalary,
                    MaxSalary = model.MaxSalary,
                    ProvinceId = model.ProvinceId,
                    TimeId = model.TimeId,
                    SkillId = model.SkillId,
                    TitleId = model.TitleId,
                    AppUserId = id
                };
                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
                return Redirect("/employer/job/" + id);
            }
            return View(model);
        }

        [Route("{id}/update")]
        public IActionResult Update(int id)
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces.OrderBy(p => p.Id), "Id", "Name");
            ViewData["TimeId"] = new SelectList(_context.Times.OrderBy(t => t.Id), "Id", "Name");
            ViewData["SkillId"] = new SelectList(_context.Skills.OrderBy(s => s.Name), "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Titles.OrderBy(t => t.Name), "Id", "Name");
            var job = _context.Jobs.Where(j => j.Id == id).First();
            return View(job);
        }


        [Route("{id}/update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateJobViewModel model)
        {
            Job job = _context.Jobs.Where(j => j.Id == id).First();
            job.Name = model.Name;
            job.Slug = TextHelper.ToUnsignString(job.Name).ToLower();
            job.Description = model.Description;
            job.Introduce = model.Introduce;
            job.Experience = model.Experience;
            job.ObjectTarget = model.ObjectTarget;
            job.MinAge = model.MinAge;
            job.MaxAge = model.MaxAge;
            job.MinSalary = model.MinSalary;
            job.MaxSalary = model.MaxSalary;
            job.ProvinceId = model.ProvinceId;
            job.TimeId = model.TimeId;
            job.SkillId = model.SkillId;
            job.TitleId = model.TitleId;
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return Redirect("/employer/job/" + job.AppUserId);
        }

        [HttpGet("{id}/delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Job job = _context.Jobs.Where(s => s.Id == id).First();
                _context.Jobs.Remove(job);
                _context.SaveChanges();
                return Redirect("/employer/job/" + job.AppUserId);
            }
            catch (System.Exception)
            {
                Job job = _context.Jobs.Where(s => s.Id == id).First();
                return Redirect("/employer/job/" + job.AppUserId);
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            var jobs = await _context.Jobs.Where(j => listDelete.Contains(j.Id)).ToListAsync();
            foreach (var job in jobs)
            {
                _context.Jobs.Remove(job);
            }
            await _context.SaveChangesAsync();

            // Lấy giá trị id của người dùng từ một trong các job đã xóa
            var userId = jobs.FirstOrDefault()?.AppUserId;

            // Trả về trang Index với giá trị id
            return RedirectToAction("Index", new { id = userId });
        }
    }
}