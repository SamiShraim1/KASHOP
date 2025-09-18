using KASHOP.BLL.Services.AuthenticationServices;
using KASHOP.DAL.Data.DTOs.Authentication.Requests;
using KASHOP.DAL.Data.DTOs.Authentication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Araes.Identity
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserResponseDTO>> Register(RegisterRequestDTO requestDTO)
        {
            var result = await _authenticationService.RegisterAsync(requestDTO);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserResponseDTO>> Login(LoginRequestDTO requestDTO)
        {
            var result = await _authenticationService.LoginAsync(requestDTO);
            return Ok(result);
        }

    }
}
