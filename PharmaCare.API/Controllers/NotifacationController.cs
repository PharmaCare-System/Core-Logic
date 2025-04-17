using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.NotifaciionDTOs;
using PharmaCare.BLL.Services.NotifacationService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifacationController : ControllerBase
    {
        private readonly INotifacationService _service;
        public NotifacationController(INotifacationService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var notifications = _service.GetAll();
            return Ok(notifications);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var notification = _service.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }
        [HttpPost]
        public IActionResult Add( NotifacationAddDto notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }
            _service.Add(notification);
            return CreatedAtAction(nameof(GetById), notification);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, NotifacationUpdateDto notification)
        {
            if (id != notification.Id)
            {
                return BadRequest();
            }
            var existingNotification = _service.GetById(id);
            if (existingNotification == null)
            {
                return NotFound();
            }
            _service.Update(notification);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var notification = _service.GetById(id);
            if (notification == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return NoContent();
        }
    }
}
