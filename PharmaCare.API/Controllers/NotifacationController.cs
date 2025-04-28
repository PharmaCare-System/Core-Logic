using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.NotificationDTOs;
using PharmaCare.BLL.Services.NotificationService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetAllAsync();
            return Ok(notifications);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _notificationService.GetAsyncById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
        [HttpPost]
        public IActionResult Add( NotifacationAddDTO notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }
            _notificationService.Add(notification);
            return CreatedAtAction(nameof(GetById), notification);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notification = _notificationService.GetAsyncById(id);
            if (notification == null)
            {
                return NotFound();
            }
            _notificationService.Delete(id);
            return NoContent();
        }
    }
}
