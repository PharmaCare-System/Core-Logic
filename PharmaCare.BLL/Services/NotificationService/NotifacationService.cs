using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.Notification.Customer;
using PharmaCare.DAL.Repository.Notification.Pharmacy;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.BLL.Services.NotificationService;
using PharmaCare.DAL.ExtensionMethods;

namespace PharmaCare.BLL.Services.NotificationService
{
    public class NotifacationService : INotificationService
    {
        private readonly ICustomerNotificationRepository _customerNotifacationRepository;
        private readonly IPharmacyNotificationRepository _pharmacyNotifacationRepository;
        public NotifacationService(ICustomerNotificationRepository customerNotificationRepository, IPharmacyNotificationRepository pharmacyNotifacationRepository)
        {
            _customerNotifacationRepository = customerNotificationRepository;
            _pharmacyNotifacationRepository = pharmacyNotifacationRepository;
        }

        public async Task Add(NotifacationAddDTO notifacationDto)
        {
            //var notifacationDTO = new Notification
            //{
            //    RecieverId = notifacationDto.UsesrId,
            //    Sender = notifacationDto.Sender,
            //    Message = notifacationDto.Message,
            //    CreatedAt = notifacationDto.CreatedAt,
            //    IsRead = notifacationDto.IsRead,
            //    Inventory = notifacationDto.Inventory,
            //};
             //await _notifacationRepository.AddAsync(notifacationDTO);

        }

        public async Task Delete(int id)
        {

            var notifacationModelCust = await _customerNotifacationRepository.GetAsyncById(id);

            if(notifacationModelCust != null){
                await _customerNotifacationRepository.DeleteAsync(notifacationModelCust);
            }

            var notifacationModelPha = await _pharmacyNotifacationRepository.GetAsyncById(id);
            if (notifacationModelPha != null)
            {
                await _pharmacyNotifacationRepository.DeleteAsync(notifacationModelPha);
            }
        }

        public async Task<IEnumerable<NotifacationReadDTO>> GetAllAsync()
        {
            // TODO: Edit to handel pharmacy also:
            // - potential solution: get usertype as parmater
            var notifacationModels = await _customerNotifacationRepository.GetAllAsync();
            var notifacationDTOs = notifacationModels.Select(n => new NotifacationReadDTO
            {
                Id = n.Id,
                UserId = n.UserId,
                UserType = n.UserType,
                Message = n.Message,
                CreatedAt = n.CreatedAt,
                IsRead = n.IsRead
            }).ToList();
            return notifacationDTOs;
        }

        public async Task<NotifacationReadDTO> GetAsyncById(int id)
        {
            // TODO: Edit to handel pharmacy also:
            // - potential solution: get usertype as parmater
            var notifacationModel = await _customerNotifacationRepository.GetAsyncById(id);
            id.CheckIfNull(notifacationModel);
            var notifacationDTO = new NotifacationReadDTO
            {
                Id = notifacationModel.Id,
                UserId = notifacationModel.UserId,
                UserType = notifacationModel.UserType,
                Message = notifacationModel.Message,
                CreatedAt = notifacationModel.CreatedAt,
                IsRead = notifacationModel.IsRead
            };
            return notifacationDTO;
        }

        public async Task<IEnumerable<NotifacationReadDTO>> GetUnreadNotificationsAsync(int userId)
        {
            // TODO: Edit to handel pharmacy also:
            // - potential solution: get usertype as parmater
            var unreadNotificationsModels = await _customerNotifacationRepository.GetUnreadCustomerNotificationsAsync(userId);
            var unreadNotificationDTOs = unreadNotificationsModels.Select(n => new NotifacationReadDTO
            {
                Id = n.Id,
                UserId = n.UserId,
                UserType = n.UserType,
                Message = n.Message,
                CreatedAt = n.CreatedAt,
                IsRead = n.IsRead
            }).ToList();
            return unreadNotificationDTOs;


        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            // TODO: Edit to handel pharmacy also:
            // - potential solution: get usertype as parmater
            var notification = await _customerNotifacationRepository.GetAsyncById(notificationId);
            notificationId.CheckIfNull(notification);
            notification.IsRead = true;
            await _customerNotifacationRepository.UpdateAsync(notification);
        }
    }
}
