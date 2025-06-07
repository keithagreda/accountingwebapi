using accountingwebapi.Dtos.Company;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<CompanyDto>>>> GetAll([FromQuery] GetCompanyInput input)
        {
            return Ok(await _companyService.GetAll(input));
        }
        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result<Ulid>>> CreateOrEdit(CreateOrEditCompanyDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _companyService.CreateOrEdit(input);
        }
    }
}
