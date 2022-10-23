
using AspNetCoreAuthentication.BLL.Models.Users;

namespace AspNetCoreAuthentication.BLL.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserManagerResponseDTO> RegisterUserAsync(RegisterUserRequestDTO requestDTO);
    }
}
