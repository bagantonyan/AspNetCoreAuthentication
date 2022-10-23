using AspNetCoreAuthentication.BLL.Models.Abstractions;

namespace AspNetCoreAuthentication.BLL.Models.Users
{
    public class LoginUserResponseDTO : BaseResponseDTO
    {
        public string Token { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
