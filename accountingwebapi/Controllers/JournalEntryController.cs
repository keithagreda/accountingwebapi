using accountingwebapi.Dtos.JournalEntry;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntryController : ControllerBase
    {
        private readonly IJournalEntryService _journalEntryService;
        public JournalEntryController(IJournalEntryService journalEntryService)
        {
            _journalEntryService = journalEntryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<JournalEntryDto>>>> GetAll([FromQuery]GetJournalEntryInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _journalEntryService.GetAll(input);

            if (res.IsSuccess)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult<Result>> CreateOrEdit(CreateOrEditJournalEntryDto input, Ulid? templateId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _journalEntryService.CreateOrEdit(input, templateId);

            if (res.IsSuccess)
            {
                return Ok(res);
            }

            return BadRequest(res);
        }
    }
}
