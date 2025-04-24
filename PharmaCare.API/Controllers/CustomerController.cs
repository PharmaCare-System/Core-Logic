//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PharmaCare.BLL.DTOs.CustomerDTOs;
//using PharmaCare.BLL.Services.CustomerService;

//namespace PharmaCare.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly CustomerService _service;
//        public CustomerController(CustomerService service)
//        {
//            _service = service;
//        }

//        // Add, Update, Delete, GetAll, GetById

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var customers= _service.GetAll();
//            if(customers == null)
//                return NotFound(); 
//            return Ok(customers);
//        }
//        [HttpGet]
//        [Route("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var customer = _service.GetById(id);
//            if (customer == null)
//                return NotFound();
//            return Ok(customer);
//        }

//        [HttpPost]
//        public IActionResult Add(CustomerAddDTO customer)
//        {
//            _service.Add(customer);
//            return CreatedAtAction(nameof(GetById),  new { Message = "Created Successfully" });
//        }

//        [HttpPut]
//        public IActionResult Update(int id, CustomerUpdateDTO customer)
//        {
//            var customerToEdit = _service.GetById(id);
//            if (customerToEdit.Id != id)
//                return BadRequest();
//            _service.Update(customer, id);
//            return CreatedAtAction(nameof(GetById), new { Message = "Updated Successfully" });

//        }


//    }
//}
