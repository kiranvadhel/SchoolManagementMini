using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherDashboardController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherDashboardController(SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalSubjects = _context.Subjects.Count();
            ViewBag.TotalClasses = _context.SchoolClasses.Count();
            return View();
        }
    }
}
