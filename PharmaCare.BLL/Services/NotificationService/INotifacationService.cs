using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.BLL.Services.NotificationService
{
    public interface INotificationService
    {
        public Task <IEnumerable<NotifacationReadDTO>> GetAllAsync();
        public Task<NotifacationReadDTO> GetAsyncById(int id);
        public Task Add(NotifacationAddDTO notifacationDto);
        public Task Delete(int id);

        Task<IEnumerable<NotifacationReadDTO>> GetUnreadNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);
    }
}
