using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.BLL.DTOs.AuthenticationDTOs;
using PharmaCare.BLL.Services.CustomerService;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.AuthenticationService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IPharmacyService _pharmacyService;
        private readonly IPharmacistService _pharmacistService;
        private readonly ICustomerService _customerService;

        public AccountService(UserManager<ApplicationUser> userManager, 
                              IConfiguration configuration, 
                              RoleManager<IdentityRole<int>> roleManager,
                              IPharmacyService pharmacyService,
                              IPharmacistService pharmacistService,
                              ICustomerService customerService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _pharmacyService = pharmacyService;
            _pharmacistService = pharmacistService;
            _customerService = customerService;
        }
        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var userEmail = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (userEmail == null)
                return null;

            var userPassword = await _userManager.CheckPasswordAsync(userEmail, loginDTO.Password);
            if (userPassword == false)
                return null;

            var claims = await _userManager.GetClaimsAsync(userEmail);
            
            return GenerateToken(claims);
        }
        /*
         1. for customer
        2. only Admin create any user
         */
        
        public async Task<string> RegisterPharmacyAsync(RegisterCustomerDTO registerDTO)
        {
            // create the pharmacist with it
            if(registerDTO.Password != registerDTO.ConfirmPassword)
                return "Passwords do not match";

            var user = new ApplicationUser()
            {
               Email = registerDTO.Email,
               UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(result.Succeeded)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Admin"));
                claims.Add(new Claim("Email", registerDTO.Email));

                await _userManager.AddClaimsAsync(user, claims);
                //_pharmacyService.Add()
                
                return GenerateToken(claims);
            }
            return null;
        }
        
        public async Task<string> RegisterCustomerAsync(RegisterCustomerDTO registerDTO)
        {
            if(registerDTO.Password != registerDTO.ConfirmPassword)
                return "Passwords do not match";

            var user = new ApplicationUser()
            {
               Email = registerDTO.Email,
               UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(result.Succeeded)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Admin"));
                claims.Add(new Claim("Email", registerDTO.Email));

                await _userManager.AddClaimsAsync(user, claims);
                return GenerateToken(claims);
            }
            return null;
        }
        
        public string GenerateToken(IList<Claim> claims)
        {
            var secreteKeyString = _configuration.GetSection("SecretKey").Value;
            var secreteKeyBytes = Encoding.ASCII.GetBytes(secreteKeyString);

            SecurityKey secreteKey = new SymmetricSecurityKey(secreteKeyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256);
            
            var expire = DateTime.UtcNow.AddDays(7);
                                                     
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: expire,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwtSecurityToken);

            return token;
        }

        public async Task<string> CreateRole(RoleAddDTO roleAddDTO)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole<int>
            {
                Name = roleAddDTO.Name,
                NormalizedName = roleAddDTO.Name.ToUpper()
            });
            if (result.Succeeded)
            {
                return "Created Successfully";
            }
            return null;
        } 

        public async Task<string> AssignRole(AssignRoleDTO roleAssignDTO)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDTO.userId);
            var role = await _roleManager.FindByIdAsync(roleAssignDTO.RoleId);

            if(user !=null && role != null)
            {
                List<Claim> claims = new List<Claim>() { 
                    new Claim(ClaimTypes.Role,role.Name),
                    //new Claim(ClaimTypes.Name,user.Id),
                };

                var result = await _userManager.AddToRoleAsync(user,role.Name);
                
                return "Assigned successfully"; ;
            }
            return null;
        }

        public async Task<List<RoleReadDTO>> GetAllRoles()
        {
            var roles = await _roleManager.Roles
                                    .Select(a => new RoleReadDTO
                                    {
                                        Id = a.Id,
                                        Name = a.Name
                                    }).ToListAsync();
            return roles;
        }
    }
}
