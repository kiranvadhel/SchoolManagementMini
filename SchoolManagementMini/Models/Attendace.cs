using System.ComponentModel.DataAnnotations;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }   // nullable to avoid CS8618

        [Required]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }   // nullable to avoid CS8618

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        public bool IsPresent { get; set; } = true;

        // Optional – many scaffolds use this; keeps things flexible
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
