using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduling1.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="The {0} must be atleast {2} charecters long.", MinimumLength = 6 )]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password and Confirm Password should match.")]
        [Display(Name="Confirm Password:")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Role.")]
        public string roleName { get; set; }
    }
}
