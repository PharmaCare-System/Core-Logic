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
            var notifications = _notificationService.GetAll();
            return Ok(notifications);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
        [HttpPost]
        public IActionResult Add( NotificationAddDto notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }
            _notificationService.Add(notification);
            return CreatedAtAction(nameof(GetById), notification);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, NotificationUpdateDto notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }
            var existingNotification = _notificationService.GetById(id);
            if (existingNotification == null)
            {
                return NotFound();
            }
            _notificationService.Update(notification);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notification = _notificationService.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }
            _notificationService.Delete(id);
            return NoContent();
        }
    }
}
