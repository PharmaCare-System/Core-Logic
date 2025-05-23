using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using PharmaCare.BLL.DTOs.AuthenticationDTOs;
using PharmaCare.BLL.DTOs.PharmayDTOs;
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
        public async Task<ActionResult> RegisterPharmacyAsync(RegitserPharmacyAndAdminDTO registerDTO)
        {
            var token = await _accountService.RegisterPharmacyAsync(registerDTO);

            if (token != null)
                return Ok(token);
            return Unauthorized();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("pharmacy/register/pharmacist")]
        public async Task<ActionResult> RegisterPharmacist(RegitserPharmacistDTO registerDTO)
        {
            var token = await _accountService.RegisterPharmacistAsync(registerDTO);

            if (token != null)
                return Ok(token);
            return Unauthorized();
        }

        [HttpPost("customer/register")]
        public async Task<ActionResult> RegisterCustomerAsync(RegisterCustomerDTO registerDTO)
        {
            var token = await _accountService.RegisterCustomerAsync(registerDTO);
             if (token!= null)
                    return Ok(token);
            
           
            return Unauthorized();
        }

        [Authorize(Roles ="Adming")]
        [HttpPost("CreateRole")]
        public async Task<ActionResult> CreateRole(RoleAddDTO roleAdd)
        {
            var result =await _accountService.CreateRole(roleAdd);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [Authorize(Roles ="Adming")]
        [HttpPost("AssignRoleToUser")]
        public async Task<ActionResult> AssignRoleToUser(AssignRoleDTO roleAssignDTO)
        {
            var result = await _accountService.AssignRole(roleAssignDTO);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("AllRoles")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> GetAllRoles()
        {
            var result = await _accountService.GetAllRoles();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
