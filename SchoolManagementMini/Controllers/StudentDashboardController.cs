using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentDashboardController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentDashboardController(SchoolDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalHomework = _context.Homeworks.Count();
            ViewBag.TotalGrades = _context.Grades.Count();
            ViewBag.TotalAttendance = _context.Attendances.Count();
            return View();
        }
    }
}
