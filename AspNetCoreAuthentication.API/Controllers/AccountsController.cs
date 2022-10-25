using AspNetCoreAuthentication.API.Models.Users;
using AspNetCoreAuthentication.BLL.Models.Users;
using AspNetCoreAuthentication.BLL.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCoreAuthentication.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountsController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid register model");

            var requestDTO = _mapper.Map<RegisterUserRequestDTO>(requestModel);

            var registerResult = await _userService.RegisterUserAsync(requestDTO);

            if (registerResult.Success)
                return Ok(registerResult);
            
            return BadRequest(registerResult);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid register model");

            var requestDTO = _mapper.Map<LoginUserRequestDTO>(requestModel);

            var loginResult = await _userService.LoginUserAsync(requestDTO);

            if (loginResult.Success)
                return Ok(loginResult);

            return BadRequest(loginResult);
        }

        [HttpGet("GetUserData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserDataAsync()
        {
            var userId = Convert.ToInt64(HttpContext.User.FindFirstValue("Id"));

            var getUserDataResult = await _userService.GetUserDataAsync(userId);

            if (getUserDataResult.Success)
                return Ok(getUserDataResult);

            return BadRequest(getUserDataResult);
        }
    }
}
