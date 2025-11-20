namespace StudentManagementSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        public DateTime EnrolledOn { get; set; } = DateTime.UtcNow;
    }
}
