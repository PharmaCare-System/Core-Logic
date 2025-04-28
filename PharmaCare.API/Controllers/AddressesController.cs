using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.Services.AddressService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerAddressById(int customerId)
        {
            var customerAddress = _addressService.GetCustomerAsyncById(customerId);
            if (customerAddress != null)
                return Ok(customerAddress);

            return BadRequest();
        }

    }
}
