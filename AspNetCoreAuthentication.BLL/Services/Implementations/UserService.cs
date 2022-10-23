using AspNetCoreAuthentication.BLL.Models.Users;
using AspNetCoreAuthentication.BLL.Services.Abstractions;
using AspNetCoreAuthentication.DAL.Entities.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreAuthentication.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserManagerResponseDTO> RegisterUserAsync(RegisterUserRequestDTO requestDTO)
        {
            if (requestDTO == null)
                throw new NullReferenceException("Register model is null");

            if (requestDTO.Password != requestDTO.ConfirmPassword)
                return new UserManagerResponseDTO
                {
                    Message = "Confirm password doesn't match to password",
                    Success = false
                };

            var user = _mapper.Map<User>(requestDTO);

            var registerResult = await _userManager.CreateAsync(user, requestDTO.Password);

            if (registerResult.Succeeded)
            {
                return new UserManagerResponseDTO
                {
                    Message = "User has created successfully",
                    Success = true
                };
            }

            return new UserManagerResponseDTO
            {
                Message = "User hasn't created",
                Success = false,
                Errors = registerResult.Errors.Select(e => e.Description)
            };
        }
    }
}
