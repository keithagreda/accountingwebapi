using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SubAccount;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountController : ControllerBase
    {
        private readonly ISubAccountService _subAccountService;
        public SubAccountController(ISubAccountService subAccountService)
        {
            _subAccountService = subAccountService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<List<GetSubAccountForViewDto>>>> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _subAccountService.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result>> CreateOrEdit(CreateOrEditSubAccountDto input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _subAccountService.CreateOrEdit(input));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
