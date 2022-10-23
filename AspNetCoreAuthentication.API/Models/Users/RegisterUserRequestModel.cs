using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAuthentication.API.Models.Users
{
    public class RegisterUserRequestModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(64, ErrorMessage = "First name can't be longer than 64 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(64, ErrorMessage = "Last name can't be longer than 64 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(64, ErrorMessage = "Email can't be longer than 64 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(64, ErrorMessage = "Phone can't be longer than 64 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(64, ErrorMessage = "Username can't be longer than 64 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password minimum length must be 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [MinLength(6, ErrorMessage = "ConfirmPassword minimum length must be 6 characters")]
        public string ConfirmPassword { get; set; }
    }
}
