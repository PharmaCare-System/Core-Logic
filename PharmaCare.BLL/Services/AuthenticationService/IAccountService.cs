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
        public Task<string> LoginAsync(LoginDTO loginDTO);
        public Task<string> RegisterPharmacyAsync(RegitserPharmacyAndAdminDTO registerDTO);
        public Task<string> RegisterPharmacistAsync(RegitserPharmacistDTO registerDTO);

        public Task<string> RegisterCustomerAsync(RegisterCustomerDTO registerDTO);
        public Task<string> CreateRole(RoleAddDTO roleAddDTO);
        public Task<string> AssignRole(AssignRoleDTO roleAssignDTO);
        public Task<List<RoleReadDTO>> GetAllRoles();
    }
}
