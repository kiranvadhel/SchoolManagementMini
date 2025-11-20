using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
