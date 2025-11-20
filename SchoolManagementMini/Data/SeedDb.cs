using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class SeedDb
    {
        private readonly SchoolDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedDb(
            SchoolDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            // ✅ STEP 1 — Ensure Roles Exist
            await CheckRoleAsync("Admin");
            await CheckRoleAsync("Teacher");
            await CheckRoleAsync("Student");

            // ✅ STEP 2 — Create Default Admin
            var adminEmail = "admin@school.com";
            if (await _userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Administrator",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(adminUser, "Admin123!");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // ✅ STEP 3 — Create Default Teacher
            var teacherEmail = "teacher@school.com";
            if (await _userManager.FindByEmailAsync(teacherEmail) == null)
            {
                var teacherUser = new User
                {
                    UserName = teacherEmail,
                    Email = teacherEmail,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(teacherUser, "Teacher123!");
                await _userManager.AddToRoleAsync(teacherUser, "Teacher");
            }

            // ✅ STEP 4 — Create Default Student
            var studentEmail = "student@school.com";
            if (await _userManager.FindByEmailAsync(studentEmail) == null)
            {
                var studentUser = new User
                {
                    UserName = studentEmail,
                    Email = studentEmail,
                    FirstName = "Alice",
                    LastName = "Smith",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(studentUser, "Student123!");
                await _userManager.AddToRoleAsync(studentUser, "Student");
            }

            // ✅ STEP 5 — Add Default Course if Not Exists
            if (!await _context.Courses.AnyAsync())
            {
                var course = new Course
                {
                    Name = "Computer Science",
                    Description = "Bachelor of Science in Computer Science",
                    IsActive = true
                };
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
            }

            // ✅ STEP 6 — Add Default Subject if Not Exists
            if (!await _context.Subjects.AnyAsync())
            {
                var course = await _context.Courses.FirstOrDefaultAsync();
                if (course != null)
                {
                    var subject = new Subject
                    {
                        Name = "Programming Fundamentals",
                        Description = "Introduction to Programming",
                        CourseId = course.Id
                    };
                    _context.Subjects.Add(subject);
                    await _context.SaveChangesAsync();
                }
            }

            // ✅ STEP 7 — Add Default SchoolClass if Not Exists
            if (!await _context.SchoolClasses.AnyAsync())
            {
                var course = await _context.Courses.FirstOrDefaultAsync();
                if (course != null)
                {
                    var schoolClass = new SchoolClass
                    {
                        ClassName = "Class A", // 🟢 Corrected property name
                        CourseId = course.Id
                    };
                    _context.SchoolClasses.Add(schoolClass);
                    await _context.SaveChangesAsync();
                }
            }

            // ✅ Final save
            await _context.SaveChangesAsync();
        }

        private async Task CheckRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
                await _roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}
