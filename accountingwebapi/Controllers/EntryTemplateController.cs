using accountingwebapi.Dtos.EntryTemplate;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryTemplateController : ControllerBase
    {
        private readonly IEntryTemplateService _entryTemplateService;
        public EntryTemplateController(IEntryTemplateService entryTemplateService)
        {
            _entryTemplateService = entryTemplateService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<GetEntryTemplateDto>>>> GetAll([FromQuery]GetEntryTemplateInputDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _entryTemplateService.GetAll(input));
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result<Ulid>>> CreateOrEdit(CreateOrEditEntryTemplateDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _entryTemplateService.CreateOrEdit(input));
        }
    }
}
