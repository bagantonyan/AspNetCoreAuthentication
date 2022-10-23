using AspNetCoreAuthentication.BLL.Models.Users;

namespace AspNetCoreAuthentication.BLL.Services.Abstractions
{
    public interface IUserService
    {
        Task<RegisterUserResponseDTO> RegisterUserAsync(RegisterUserRequestDTO requestDTO);
        Task<LoginUserResponseDTO> LoginUserAsync(LoginUserRequestDTO requestDTO);
    }
}
