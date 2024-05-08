using System.ComponentModel.DataAnnotations;
using User_Service.Models;

namespace User_Service.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Password_again {  get; set; }
    }
}
