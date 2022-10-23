using AspNetCoreAuthentication.BLL.Models.Abstractions;

namespace AspNetCoreAuthentication.BLL.Models.Users
{
    public class GetUserDataResponseDTO : BaseResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
