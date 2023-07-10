using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using X.PagedList;
using NuGet.Packaging;

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
                .Include(j => j.Skills)
                .Include(j => j.Title)
                .OrderByDescending(j => j.CreateDate)
                .ToListAsync();
            return View(jobs.ToPagedList(page ?? 1, pageSize));
        }

        [Route("{id}/create")]
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces.OrderBy(p => p.Id), "Id", "Name");
            ViewData["TimeId"] = new SelectList(_context.Times.OrderBy(t => t.Id), "Id", "Name");
            ViewData["TitleId"] = new SelectList(_context.Titles.OrderBy(t => t.Name), "Id", "Name");
            var skills = _context.Skills.OrderBy(s => s.Name).ToList();
            ViewBag.SkillId = new MultiSelectList(skills, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("{id}/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, CreateJobViewModel model)
        {
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
                    MinSalary = model.MinSalary,
                    MaxSalary = model.MaxSalary,
                    ProvinceId = model.ProvinceId,
                    TimeId = model.TimeId,
                    Skills = _context.Skills.Where(s => model.SkillIds.Contains(s.Id)).ToList(),
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
            ViewData["TitleId"] = new SelectList(_context.Titles.OrderBy(t => t.Name), "Id", "Name");

            var skills = _context.Skills.OrderBy(s => s.Name).ToList();
            ViewBag.SkillId = new MultiSelectList(skills, "Id", "Name");

            var job = _context.Jobs
                .Include(j => j.Skills)
                .Where(j => j.Id == id)
                .First();

            var model = new UpdateJobViewModel
            {
                Name = job.Name,
                Description = job.Description,
                Introduce = job.Introduce,
                ObjectTarget = job.ObjectTarget,
                Experience = job.Experience,
                ProvinceId = job.ProvinceId,
                TimeId = job.TimeId,
                MinSalary = job.MinSalary,
                MaxSalary = job.MaxSalary,
                TitleId = job.TitleId,
                SkillIds = job.Skills.Select(s => s.Id).ToList()
            };

            return View(model);
        }

        [Route("{id}/update")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateJobViewModel model)
        {
            if (ModelState.IsValid)
            {
                var job = _context.Jobs
                    .Include(j => j.Skills)
                    .FirstOrDefault(j => j.Id == id);

                if (job == null)
                {
                    return NotFound();
                }
                job.Name = model.Name;
                job.Slug = TextHelper.ToUnsignString(job.Name).ToLower();
                job.Description = model.Description;
                job.Introduce = model.Introduce;
                job.Experience = model.Experience;
                job.ObjectTarget = model.ObjectTarget;
                job.MinSalary = model.MinSalary;
                job.MaxSalary = model.MaxSalary;
                job.ProvinceId = model.ProvinceId;
                job.TimeId = model.TimeId;
                job.TitleId = model.TitleId;

                var selectedSkills = _context.Skills
                    .Where(s => model.SkillIds.Contains(s.Id))
                    .ToList();
                job.Skills.Clear();
                job.Skills.AddRange(selectedSkills);

                _context.Jobs.Update(job);
                await _context.SaveChangesAsync();
                return Redirect("/employer/job/" + job.AppUserId);
            }
            return View(model);
        }

        [HttpGet("{id}/delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Job job = _context.Jobs.Include(j => j.Skills).FirstOrDefault(s => s.Id == id);

                if (job == null)
                {
                    // Job with the given id not found
                    return NotFound();
                }

                // Remove the associated JobSkill records
                foreach (var skill in job.Skills.ToList())
                {
                    job.Skills.Remove(skill);
                }

                // Now remove the job itself
                _context.Jobs.Remove(job);

                _context.SaveChanges();
                return Redirect("/employer/job/" + job.AppUserId);
            }
            catch (System.Exception)
            {
                // Handle any exceptions if necessary
                return RedirectToAction("Index"); // Redirect to some error page or handle the error as needed
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            var jobs = await _context.Jobs
                .Include(j => j.Skills) // Include the Skills related to the Jobs
                .Where(j => listDelete.Contains(j.Id))
                .ToListAsync();

            foreach (var job in jobs)
            {
                // Remove the associated JobSkill records
                foreach (var skill in job.Skills.ToList())
                {
                    job.Skills.Remove(skill);
                }

                _context.Jobs.Remove(job);
            }

            await _context.SaveChangesAsync();

            var userId = jobs.FirstOrDefault()?.AppUserId;

            return RedirectToAction("Index", new { id = userId });
        }
    }
}