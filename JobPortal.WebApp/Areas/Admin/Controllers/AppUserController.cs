using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/users")]
    public class AppUserController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AppUserController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [Route("")]
        public IActionResult Index()
        {
            //All users but admin
            var users = userManager.Users.Where(u => u.Status != -1).ToList();
            var userRoles = new List<Dictionary<string, string>>();

            foreach (var user in users)
            {
                var roles = userManager.GetRolesAsync(user).Result;
                var roleNames = new List<string>();

                foreach (var role in roles)
                {
                    var roleName = roleManager.FindByNameAsync(role).Result.Name;
                    roleNames.Add(roleName);
                }

                userRoles.Add(new Dictionary<string, string>
                {
                    { "userId", user.Id.ToString()},
                    { "Email", user.Email },
                    { "Avatar", user.UrlAvatar },
                    { "RoleNames", string.Join(", ", roleNames) }
                });
            }

            return View(userRoles);
        }

        // Phân quyền Users
        [Route("manage-user-roles/{userId}")]
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(Guid userId)
        {
            ViewBag.userId = userId;

            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [Route("manage-user-roles/{userId}")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("Index");
        }

    }
}