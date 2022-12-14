using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAuthentication.API.Models.Users
{
    public class LoginUserRequestModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(64, ErrorMessage = "UserName can't be longer than 64 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password minimum length must be 6 characters")]
        public string Password { get; set; }
    }
}
