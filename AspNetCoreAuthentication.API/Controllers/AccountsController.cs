using AspNetCoreAuthentication.API.Models.Users;
using AspNetCoreAuthentication.BLL.Models.Users;
using AspNetCoreAuthentication.BLL.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("Register")]
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

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some properties are not valid");

            var requestDTO = _mapper.Map<LoginUserRequestDTO>(requestModel);

            var result = await _userService.LoginUserAsync(requestDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
