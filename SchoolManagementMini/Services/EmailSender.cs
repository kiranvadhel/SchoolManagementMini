using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    // Dummy email sender to avoid exceptions on Register
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // No actual email sending (silent success)
            return Task.CompletedTask;
        }
    }
}
