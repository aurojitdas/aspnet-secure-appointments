using Microsoft.AspNetCore.Identity;

namespace AppointmentScheduling1.Models
{
    //Extending the default Identity User class to add Custom properties
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
