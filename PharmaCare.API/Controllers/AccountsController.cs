using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.AuthenticationDTOs;
using PharmaCare.BLL.Services.AuthenticationService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("LoginAsync")]
        public async Task<ActionResult> LoginAsync(LoginDTO loginDTO)
        {
            var token = await _accountService.LoginAsync(loginDTO);

            if(token != null)
                return Ok(token);
            return Unauthorized();
        }
        [HttpPost("RegisterAsync")]
        public async Task<ActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var token = await _accountService.RegisterAsync(registerDTO);

            if (token != null)
                return Ok(token);
            return Unauthorized();
        }
    }
}
