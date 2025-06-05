using accountingwebapi.Dtos.IndividualAccount;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Migrations;
using accountingwebapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualAccountController : ControllerBase
    {
        private readonly IIndividualAccountService _individualAccountService;
        public IndividualAccountController(IIndividualAccountService individualAccountService)
        {
            _individualAccountService = individualAccountService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<IndividualAccountDto>>>> GetAllIndividualAccount([FromQuery]GenericSearchParam input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var query = await _individualAccountService.GetAllIndividualAccount(input);

            return Ok(query);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result>> CreateOrEdit(CreateOrEditIndividualAccount input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _individualAccountService.CreateOrEdit(input);

            return Ok(service);
        }

        [HttpPost("SeedIndividualAccount")]
        public async Task<ActionResult<Result>> SeedIndividualAccount()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = await _individualAccountService.SeedIndividualAccount();

            return Ok(service);
        }
    }
}
