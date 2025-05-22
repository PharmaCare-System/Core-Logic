using PharmaCare.BLL.DTOs.AuthenticationDTOs;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.AuthenticationService
{
    public interface IAccountService
    {
        public Task<GenerateResponses> LoginAsync(LoginDTO loginDTO);
        public Task<GenerateResponses> RegisterPharmacyAsync(RegitserPharmacyAndAdminDTO registerDTO);
        public Task<GenerateResponses> RegisterPharmacistAsync(RegitserPharmacistDTO registerDTO);
        public Task<GenerateResponses> RegisterCustomerAsync(RegisterCustomerDTO registerDTO);
        public Task<GenerateResponses> CreateRole(RoleAddDTO roleAddDTO);
        public Task<GenerateResponses> AssignRole(AssignRoleDTO roleAssignDTO);
        public Task<List<RoleReadDTO>> GetAllRoles();
    }
}
