using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.BLL.DTOs.AuthenticationDTOs;
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
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
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

        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
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
    }
}
