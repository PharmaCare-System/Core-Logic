using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.OrderDTOs;
using PharmaCare.BLL.Services.OrderService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var orders = _orderService.GetAsyncById(Id);
            return Ok(orders);
        }
        [HttpPost]
        public IActionResult Add(OrderAddDTO orderDto)
        {
            _orderService.AddAsync(orderDto);
            return CreatedAtAction(nameof(GetById), new { Message = "Order Created Successfully" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderUpdateDTO orderDto)
        {
            var order = _orderService.GetAsyncById(id);
            _orderService.UpdateAsync(id, orderDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerIdAsync(customerId);
            return Ok(orders);
        }

        [HttpGet("pharmacist/{pharmacistId}")]
        public async Task<IActionResult> GetOrdersByPharmacist(int pharmacistId)
        {
            var orders = await _orderService.GetOrdersByPharmacistIdAsync(pharmacistId);
            return Ok(orders);
        }

        [HttpGet("pharmacy/{pharmacyId}")]
        public async Task<IActionResult> GetOrdersByPharmacy(int pharmacyId)
        {
            var orders = await _orderService.GetOrdersByPharmacyIdAsync(pharmacyId);
            return Ok(orders);
        }

        [HttpGet("products/{orderId}")]
        public async Task<IActionResult> GetOrderProducts(int orderId)
        {
            var products = await _orderService.GetOrderProductsAsync(orderId);
            return Ok(products);
        }


    }
}
