namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<SchoolClass>? SchoolClasses { get; set; }
    }
}
