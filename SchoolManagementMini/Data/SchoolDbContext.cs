using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class SchoolDbContext : IdentityDbContext<User>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        // ✅ These three are the ones your controllers/views need
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Teacher ↔ Subject (many-to-many)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers);

            // Teacher ↔ SchoolClass (many-to-many)
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.SchoolClasses)
                .WithMany(c => c.Teachers);

            // Course ↔ Subject (1-many)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Subjects)
                .WithOne(s => s.Course)
                .OnDelete(DeleteBehavior.Cascade);

            // Course ↔ SchoolClass (1-many)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.SchoolClasses)
                .WithOne(sc => sc.Course)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
