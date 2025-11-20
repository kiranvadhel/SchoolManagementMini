using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly SchoolDbContext _context;

        public AdminDashboardController(SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard summary counts
            ViewBag.TotalStudents = _context.Students.Count();
            ViewBag.TotalTeachers = _context.Teachers.Count();
            ViewBag.TotalCourses = _context.Courses.Count();
            ViewBag.TotalSubjects = _context.Subjects.Count();

            return View();
        }
    }
}
