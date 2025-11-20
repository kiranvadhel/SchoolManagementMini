namespace StudentManagementSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public bool IsSubmitted { get; set; } = false;
    }
}
