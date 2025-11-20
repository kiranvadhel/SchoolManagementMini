using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; } = string.Empty;

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // ✅ Add StartDate property
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        // ✅ Add EndDate property (fixes your latest error)
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(6);

        // ✅ Optional navigation properties
        public ICollection<Student>? Students { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
