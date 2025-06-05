using accountingwebapi.Dtos.Result;
using accountingwebapi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace accountingwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingPeriodController : ControllerBase
    {
        private readonly IAccountingPeriodService _accountingPeriodService;
        public AccountingPeriodController(IAccountingPeriodService accountingPeriodService)
        {
            _accountingPeriodService = accountingPeriodService;
        }

        [HttpPost("CloseCurrentAccountingPeriod")]
        public async Task<ActionResult<Result>> CloseCurrentAccountingPeriod()
        {
            return Ok(await _accountingPeriodService.CloseCurrentAccountingPeriod());
        }
        [HttpPost("AccountingPeriodHandler")]
        public async Task<ActionResult<Result<int>>> AccountingPeriodHandler()
        {
            return Ok(await _accountingPeriodService.AccountingPeriodHandler());
        }
    }
}
