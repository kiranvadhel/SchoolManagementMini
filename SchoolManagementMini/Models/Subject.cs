using System.Diagnostics;

namespace StudentManagementSystem.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Homework>? Homeworks { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
