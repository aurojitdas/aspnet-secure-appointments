using Microsoft.AspNetCore.Identity;

namespace AppointmentScheduling1.Models
{
    //Extending the default Identity User class to add Custom properties
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? MedicalId { get; set; }
        public bool? assignMentStatus { get; set; }
        public string? AssignedTo { get; set; }

    }
}
