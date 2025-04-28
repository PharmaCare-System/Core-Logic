using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.NotificationRepository;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.BLL.Services.NotificationService;
using PharmaCare.DAL.ExtensionMethods;

namespace PharmaCare.BLL.Services.NotificationService
{
    public class NotifacationService : INotificationService
    {
        private readonly INotificationRepository _notifacationRepository;
        public NotifacationService(INotificationRepository notifacationRepository)
        {
            _notifacationRepository = notifacationRepository;
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
            var notifacationModel = await _notifacationRepository.GetAsyncById(id);
            id.CheckIfNull(notifacationModel);
           await _notifacationRepository.DeleteAsync(notifacationModel);
        }

        public async Task<IEnumerable<NotifacationReadDTO>> GetAllAsync()
        {
            var notifacationModels = await _notifacationRepository.GetAllAsync();
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
            var notifacationModel = await _notifacationRepository.GetAsyncById(id);
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
            var unreadNotificationsModels = await _notifacationRepository.GetUnreadNotificationsAsync(userId);
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
            var notification = await _notifacationRepository.GetAsyncById(notificationId);
            notificationId.CheckIfNull(notification);
            notification.IsRead = true;
            await _notifacationRepository.UpdateAsync(notification);
        }
    }
}
