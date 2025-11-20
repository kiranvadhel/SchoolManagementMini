using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        // Link to Identity User (admin@school.com etc.)
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Qualification")]
        public string Qualification { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        // Optional: Navigation for teaching assignments
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}
