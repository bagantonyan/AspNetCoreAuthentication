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
    }
}
