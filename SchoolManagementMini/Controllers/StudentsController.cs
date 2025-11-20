using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly UserManager<User> _userManager;

        public StudentsController(SchoolDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ✅ GET: Students/Create
        public async Task<IActionResult> Create()
        {
            // Load all classes for the dropdown
            ViewData["SchoolClassId"] = new SelectList(await _context.SchoolClasses.ToListAsync(), "Id", "Name");
            return View();
        }

        // ✅ POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Auto-assign UserId to logged-in user
                var userId = _userManager.GetUserId(User);
                student.UserId = userId;

                _context.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Reload the dropdown if validation fails
            ViewData["SchoolClassId"] = new SelectList(_context.SchoolClasses, "Id", "Name", student.SchoolClassId);
            return View(student);
        }
    }
}
