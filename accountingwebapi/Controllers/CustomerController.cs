using accountingwebapi.Dtos.Customer;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<GetCustomerOutput>>> GetAll([FromQuery]GetCustomerInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _customerService.GetAll(input));
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result<Ulid>>> CreateOrEdit(CreateOrEditCustomerDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _customerService.CreateOrEdit(input));
        }
    }
}
