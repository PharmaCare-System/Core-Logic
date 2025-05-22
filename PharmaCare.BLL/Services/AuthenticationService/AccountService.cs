using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmaCare.BLL.DTOs.AuthenticationDTOs;
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using PharmaCare.BLL.Services.CustomerService;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.Customers;
using PharmaCare.DAL.Repository.Pharmacists;
using pharmacy.DAL;
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
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IPharmacistRepository _pharmacistRepository;
        private readonly ICustomerRepository _customerRepository;

        public AccountService(UserManager<ApplicationUser> userManager, 
                              IConfiguration configuration, 
                              RoleManager<IdentityRole<int>> roleManager,
                              IPharmacyRepository pharmacyRepository,
                              IPharmacistRepository pharmacistRepository,
                              ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _pharmacyRepository = pharmacyRepository;
            _pharmacistRepository = pharmacistRepository;
            _customerRepository = customerRepository;
        }
        public async Task<GenerateResponses> LoginAsync(LoginDTO loginDTO)
        {
            GenerateResponses response = new GenerateResponses();
            var userEmail = await _userManager.FindByEmailAsync(loginDTO.Email);

            var userPassword = await _userManager.CheckPasswordAsync(userEmail, loginDTO.Password);
            if (userPassword == false || userEmail == null)
            {
                response.Success = false;
                response.Errors.Add("Invalid Email Or Password");
                return response;
            }

            var claims = await _userManager.GetClaimsAsync(userEmail);
            response.Success = true;
            response.token = GenerateToken(claims);
            return response;
        }


        public async Task<GenerateResponses> RegisterPharmacyAsync(RegitserPharmacyAndAdminDTO registerDTO)
        {
            GenerateResponses responses = new GenerateResponses();

            // create the pharmacist with it
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                responses.Success = false;
                responses.Errors.Add("Passwords do not match");
                return responses;

            }
            // create pharmacy

            var PharmacyModel = new Pharmacy()
            {
                Name = registerDTO.Name,
                Location = registerDTO.Address 
            };
            await _pharmacyRepository.AddAsync(PharmacyModel);

            var PharmacistModel = new Pharmacist
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                PharmacyId =PharmacyModel.Id,
                Age = registerDTO.Age,
            };
            await _pharmacistRepository.AddAsync(PharmacistModel);

            PharmacyModel.MangerPharmacyId = PharmacistModel.Id;
            await _pharmacyRepository.UpdateAsync(PharmacyModel);

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

                // create role if not exist
                var Allroles = await GetAllRoles();
                if(Allroles.FirstOrDefault(x => x.Name == "Admin") == null)
                {
                    await CreateRole(new RoleAddDTO() { Name = "Admin" });
                }
                
               GenerateResponses assignResult = await AssignRole(new AssignRoleDTO()
                {
                    userId = PharmacistModel.Id,
                    RoleId = (await GetAllRoles()).FirstOrDefault(x => x.Name == "Admin").Id

                });
                if (assignResult.Success)
                {
                    responses.Success = true;
                    responses.token = GenerateToken(claims);
                    return responses;
                }

                responses.Success = false;
                responses.Errors = assignResult.Errors;
                return responses;

            }
            responses.Success = true;
            responses.Errors = result.Errors.Select(a => a.Description).ToList();
            return responses;
        }

        public async Task<GenerateResponses> RegisterPharmacistAsync(RegitserPharmacistDTO registerDTO)
        {
            GenerateResponses responses = new GenerateResponses();

            // create the pharmacist with it
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                responses.Success = false;
                responses.Errors.Add("Passwords do not match");
                return responses;

            }

            var PharmacistModel = new Pharmacist
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                PharmacyId = registerDTO.pharmacyId,
                Age = registerDTO.Age,
            };


            var user = new ApplicationUser()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Pharmacist"));
                claims.Add(new Claim("Email", registerDTO.Email));

                await _userManager.AddClaimsAsync(user, claims);

                var Allroles = await GetAllRoles();

                if (Allroles.FirstOrDefault(x => x.Name == "Pharmacist") == null)
                {
                    await CreateRole(new RoleAddDTO() { Name = "Pharmacist" });
                }
                GenerateResponses assignresult = await AssignRole(new AssignRoleDTO()
                {
                    userId = PharmacistModel.Id,
                    RoleId = (await GetAllRoles()).FirstOrDefault(x => x.Name == "Pharmacist").Id

                });
                if (assignresult.Success)
                {
                    responses.Success = true;
                    responses.token = GenerateToken(claims);
                    return responses;
                }

                responses.Success = false;
                responses.Errors = assignresult.Errors;
                return responses;

                
            }
            responses.Success = true;
            responses.Errors = result.Errors.Select(a => a.Description).ToList();
            return responses;
        }

        public async Task<GenerateResponses> RegisterCustomerAsync(RegisterCustomerDTO registerDTO)
        {
            GenerateResponses responses = new GenerateResponses();

            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                responses.Success = false;
                responses.Errors.Add("Passwords do not match");
                return responses;

            }

            var customerModel = new Customer()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Age = registerDTO.Age,
                Email = registerDTO.Email,
                Birthday = registerDTO.BirthDate,
                PhoneNumber = registerDTO.PhoneNumber
            };
            await _customerRepository.AddAsync(customerModel);

            var user = new ApplicationUser()
            {
               Email = registerDTO.Email,
               UserName = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if(result.Succeeded)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Customer"));
                claims.Add(new Claim("Email", registerDTO.Email));

                await _userManager.AddClaimsAsync(user, claims);
                var Allroles = await GetAllRoles();

                if (Allroles.FirstOrDefault(x => x.Name == "Customer") == null)
                {
                    await CreateRole(new RoleAddDTO() { Name = "Customer" });
                }

                GenerateResponses assingResult = await AssignRole(new AssignRoleDTO()
                {
                    userId = customerModel.Id,
                    RoleId = (await GetAllRoles()).FirstOrDefault(x => x.Name == "Customer").Id

                });
                if (assingResult.Success)
                {
                    responses.Success = true;
                    responses.token = GenerateToken(claims);
                    return responses;
                }

                responses.Success = false;
                responses.Errors = assingResult.Errors;
                return responses;
            }
            responses.Success = true;
            responses.Errors = result.Errors.Select(a=>a.Description).ToList();
            return responses;
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

        public async Task<GenerateResponses> CreateRole(RoleAddDTO roleAddDTO)
        {
            GenerateResponses responses = new GenerateResponses();

            var result = await _roleManager.CreateAsync(new IdentityRole<int>
            {
                Name = roleAddDTO.Name,
                NormalizedName = roleAddDTO.Name.ToUpper()
            });
            if (result.Succeeded)
            {
                responses.Success = true;
                return responses;
            }
            responses.Success = false;
            responses.Errors.Add("Failed to create the role");
            return responses;
        } 

        public async Task<GenerateResponses> AssignRole(AssignRoleDTO roleAssignDTO)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDTO.userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleAssignDTO.RoleId.ToString());
            GenerateResponses responses = new GenerateResponses();
            if (user !=null && role != null)
            {
                List<Claim> claims = new List<Claim>() { 
                    new Claim(ClaimTypes.Role,role.Name),
                    //new Claim(ClaimTypes.Name,user.Id),
                };

                var result = await _userManager.AddToRoleAsync(user,role.Name);

                if (result.Succeeded)
                {
                    responses.Success = true;
                    return responses;
                }
                responses.Success= false;
                responses.Errors = result.Errors.Select(a => a.Description).ToList();

                return responses ;
            }
            responses.Success = false;
            responses.Errors.Add("User or Role doesn't Exist");
            return responses;
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
