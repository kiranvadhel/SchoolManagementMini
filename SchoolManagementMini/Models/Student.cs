using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        // This links to ASP.NET Identity user, but will be auto-set — not manually entered
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Display(Name = "Roll Number")]
        public string RollNumber { get; set; }

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [Display(Name = "Class")]
        public int? SchoolClassId { get; set; }
        public SchoolClass? SchoolClass { get; set; }

        // Optional: Relationships
        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Homework>? Homeworks { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
