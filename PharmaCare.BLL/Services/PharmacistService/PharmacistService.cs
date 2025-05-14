//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PharmaCare.BLL.DTOs.PharmacistDTOs;
//using pharmasist.DAL;

//namespace PharmaCare.BLL.Services.PharmacistService
//{
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.Pharmacists;

public class PharmacistService : IPharmacistService
{
    private readonly IPharmacistRepository _pharmacistRepository;
    public PharmacistService(IPharmacistRepository pharmacistRepository)
    {
        _pharmacistRepository = pharmacistRepository;
    }



    public async Task AddAsync(PharmacistAddDTO pharmacistAddDto)
    {
        var pharmacistModel = new Pharmacist
        {
            FirstName = pharmacistAddDto.FirstName,
            LastName = pharmacistAddDto.LastName,
            Email = pharmacistAddDto.Email,
            IsActive = true,
            Phone = pharmacistAddDto.Phone,
            PharmacyId = pharmacistAddDto.PharmacyId,
            Age = pharmacistAddDto.Age,
            ManagerId = pharmacistAddDto.ManagerPharmacistId,
        };
        await _pharmacistRepository.AddAsync(pharmacistModel);
    }



    public async Task DeleteAsync(int id)
    {
        var pharmacistModel = await _pharmacistRepository.GetAsyncById(id);
        id.CheckIfNull(pharmacistModel);
        pharmacistModel.IsActive = false;
        await _pharmacistRepository.SoftDelete(pharmacistModel);
    }
    public async Task<IEnumerable<PharmacistReadDTO>> GetAllAsync()
    {
        var pharmacistsModels = await _pharmacistRepository.GetAllAsync();
        var pharmacistDTOs = pharmacistsModels.Select(p => new PharmacistReadDTO
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            PharmacyId = p.PharmacyId,
            ManagerPharmacistId = p.ManagerId
        }).ToList();
        return pharmacistDTOs;
    }
    public async Task<PharmacistReadDTO> GetAsyncById(int id)
    {
        var pharmacistModel = await _pharmacistRepository.GetAsyncById(id);
        id.CheckIfNull(pharmacistModel);
        var pharmacistDTO = new PharmacistReadDTO
        {
            Id = pharmacistModel.Id,
            FirstName = pharmacistModel.FirstName,
            LastName = pharmacistModel.LastName,
            Email = pharmacistModel.Email,
            Phone = pharmacistModel.Phone,
            PharmacyId = pharmacistModel.PharmacyId,
            ManagerPharmacistId = pharmacistModel.ManagerId
        };
        return pharmacistDTO;
    }

    public async Task<PharmacistChatsDTO> GetPharmacistChats(int id)
    {
        var pharmacistModel = await _pharmacistRepository.GetPharmacistChats(id);
        id.CheckIfNull(pharmacistModel);
        var pharmacistDTO = new PharmacistChatsDTO
        {
            Id = pharmacistModel.Id,
            FirstName = pharmacistModel.FirstName,
            LastName = pharmacistModel.LastName,
            Messages = pharmacistModel.Messages.Select(m => new PharmacistChatMessageDTO
            {
                Id = m.Id,
                MessageDate = m.MessageDate,
                MessageText = m.MessageText,
                UserType = m.UserType
            }).ToList()

        };

        return pharmacistDTO;

    }

    public async Task<IEnumerable<PharmacistReadDTO>> GetPharmacistsByPharmacyId(int pharmacyId)
    {
        var pharmacistsModels = await _pharmacistRepository.GetPharmacistByPharmacyId(pharmacyId);
        var pharmacistDTOs = pharmacistsModels.Select(p => new PharmacistReadDTO
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            PharmacyId = p.PharmacyId,
            ManagerPharmacistId = p.ManagerId
        }).ToList();
        return pharmacistDTOs;
    }



    public async Task UpdateAsync(PharmacistUpdateDTO pharmacistDTO, int id)
    {
        var pharmacistModel = await _pharmacistRepository.GetAsyncById(id);
        id.CheckIfNull(pharmacistModel);
        pharmacistModel.FirstName = pharmacistDTO.FirstName;
        pharmacistModel.LastName = pharmacistDTO.LastName;
        pharmacistModel.Email = pharmacistDTO.Email;
        pharmacistModel.Phone = pharmacistDTO.Phone;
        pharmacistModel.Age = pharmacistDTO.Age;

        pharmacistModel.Password = pharmacistDTO.Password;

        pharmacistModel.PharmacyId = pharmacistDTO.PharmacyId;

        pharmacistModel.ManagerId = pharmacistDTO.ManagerPharmacistId;

        await _pharmacistRepository.UpdateAsync(pharmacistModel);

    }
    public async Task<IEnumerable<PharmacistReadDTO>> AvialbelForChat()
    {
        var pharmacistsModels = await _pharmacistRepository.AvialbelForChat();
        var pharmacistDTOs = pharmacistsModels.Select(p => new PharmacistReadDTO
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            PharmacyId = p.PharmacyId,
            ManagerPharmacistId = p.ManagerId
        }).ToList();
        return pharmacistDTOs;
    }
}

