using AspNetCoreAuthentication.BLL.Models.Users;
using AspNetCoreAuthentication.BLL.Services.Abstractions;
using AspNetCoreAuthentication.DAL.Entities.Users;
using AspNetCoreAuthentication.DAL.Repositories.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreAuthentication.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            IUserRepository userRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<RegisterUserResponseDTO> RegisterUserAsync(RegisterUserRequestDTO requestDTO)
        {
            if (requestDTO == null)
                throw new NullReferenceException("Register model is null");

            if (requestDTO.Password != requestDTO.ConfirmPassword)
                return new RegisterUserResponseDTO
                {
                    Message = "Confirm password doesn't match to password",
                    Success = false
                };

            var user = _mapper.Map<User>(requestDTO);

            var registerResult = await _userManager.CreateAsync(user, requestDTO.Password);

            if (registerResult.Succeeded)
            {
                return new RegisterUserResponseDTO
                {
                    Message = "User has created successfully",
                    Success = true
                };
            }

            return new RegisterUserResponseDTO
            {
                Message = "User hasn't created",
                Success = false,
                Errors = registerResult.Errors.Select(e => e.Description)
            };
        }

        public async Task<LoginUserResponseDTO> LoginUserAsync(LoginUserRequestDTO requestDTO)
        {
            var user = await _userManager.FindByNameAsync(requestDTO.UserName);

            if (user == null)
                return new LoginUserResponseDTO
                {
                    Message = "No user with specified Email",
                    Success = false
                };

            var loginResult = await _userManager.CheckPasswordAsync(user, requestDTO.Password);

            if (!loginResult)
                return new LoginUserResponseDTO
                {
                    Message = "Wrong password",
                    Success = false
                };

            var claims = new[]
{
                new Claim("UserName", requestDTO.UserName),
                new Claim("Id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginUserResponseDTO
            {
                Message = "Login Successfull",
                Token = tokenAsString,
                Success = true,
                ExpirationDate = token.ValidTo
            };
        }

        public async Task<GetUserDataResponseDTO> GetUserDataAsync(long id)
        {
            var currentUser = await _userRepository.GetByIdAsync(id);

            if (currentUser == null)
                return new GetUserDataResponseDTO
                {
                    Message = "User not found",
                    Success = false
                };

            var getUserResult = _mapper.Map<GetUserDataResponseDTO>(currentUser);
            getUserResult.Success = true;

            return getUserResult;
        }
    }
}
