using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
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

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginDTO loginDTO)
        {
            var token = await _accountService.LoginAsync(loginDTO);

            if(token != null)
                return Ok(token);
            return Unauthorized();
        }
        [HttpPost("pharmacy/register")]
        public async Task<ActionResult> RegisterPharmacyAsync(RegisterCustomerDTO registerDTO)
        {
            var token = await _accountService.RegisterPharmacyAsync(registerDTO);

            if (token != null)
                return Ok(token);
            return Unauthorized();
        }

        [HttpPost("customer/register")]
        public async Task<ActionResult> RegisterCustomerAsync(RegisterCustomerDTO registerDTO)
        {
            var token = await _accountService.RegisterCustomerAsync(registerDTO);

            if (token != null)
                return Ok(token);
            return Unauthorized();
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole(RoleAddDTO roleAdd)
        {
            var result = _accountService.CreateRole(roleAdd);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("AssignRoleToUser")]

        public async Task<ActionResult> AssignRoleToUser(AssignRoleDTO roleAssignDTO)
        {
            var result = _accountService.AssignRole(roleAssignDTO);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("AllRoles")]

        public async Task<ActionResult> GetAllRoles()
        {
            var result = _accountService.GetAllRoles();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
