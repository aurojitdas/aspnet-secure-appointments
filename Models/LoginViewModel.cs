using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling1.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Username")]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name="Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
