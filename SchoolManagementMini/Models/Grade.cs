using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }   // nullable to avoid CS8618

        [Required]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }   // nullable to avoid CS8618

        // Keep Teacher optional so scaffolds that reference it won’t break
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        // ✅ Your views/controllers earlier expected Score (not Marks)
        [Required, Range(0, 100)]
        public double Score { get; set; }

        public string? Remarks { get; set; }

        // ✅ Your views referenced DateAssigned
        public DateTime DateAssigned { get; set; } = DateTime.Now;
    }
}
