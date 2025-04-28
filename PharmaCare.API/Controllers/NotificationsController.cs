using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.BLL.Services.NotificationService;
using PharmaCare.DAL.ExtensionMethods;



namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly  INotificationService _notifacationService;
        public NotificationsController(INotificationService notifacationService)
        {
            _notifacationService = notifacationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notificationModels = await _notifacationService.GetAllAsync();
            return Ok(notificationModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var notificationModel = await _notifacationService.GetAsyncById(id);
            id.CheckIfNull(notificationModel);

            return Ok(notificationModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add( NotifacationAddDTO notifacationDto)
        {
            if (notifacationDto == null)
            {
                return BadRequest("Notification data is null");
            }
            await _notifacationService.Add(notifacationDto);
            return CreatedAtAction(nameof(GetById), new { message = "Notification Created Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var notificationModel = await _notifacationService.GetAsyncById(id);
         id.CheckIfNull(notificationModel);
            await _notifacationService.Delete(id);
            return NoContent();
        }

        [HttpGet("unread/{userId}")]
        public async Task<IActionResult> GetUnreadNotifications(int userId)
        {
            var unreadNotifications = await _notifacationService.GetUnreadNotificationsAsync(userId);
            return Ok(unreadNotifications);
        }

        [HttpPut("mark-as-read/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var notification = await _notifacationService.GetAsyncById(notificationId);
            notificationId.CheckIfNull(notification);
            await _notifacationService.MarkAsReadAsync(notificationId);
            return NoContent();
        }
    }
}
