using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.CustomerDTOs;
using PharmaCare.BLL.Services.CustomerService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers == null)
                return NotFound();

            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsyncById(int id)
        {
            var customer = await _customerService.GetAsyncById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CustomerAddDTO customerDTO)
        {
            await _customerService.AddAsync(customerDTO);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CustomerUpdateDTO customerDTO)
        {
            var customer = await _customerService.GetAsyncById(id);
            if (customer.Id != id)
                return BadRequest();

            await _customerService.UpdateAsync(customerDTO, id);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
             await _customerService.DeleteAsync(id);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Deleted Successfully" });
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
