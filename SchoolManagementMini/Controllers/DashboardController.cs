using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<User> _userManager;

        public DashboardController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.Role = roles.FirstOrDefault() ?? "Student"; // Default to student

            return View(user);
        }
    }
}
