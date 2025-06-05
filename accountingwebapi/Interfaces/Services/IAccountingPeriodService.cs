using accountingwebapi.Dtos.AccountingPeriod;
using accountingwebapi.Dtos.Result;

namespace accountingwebapi.Interfaces.Services
{
    public interface IAccountingPeriodService
    {
        Task<Result<int>> AccountingPeriodHandler();
        Task<Result<AccountingPeriodDto>> GetCurrentOpenedAccountingPeriod();
        Task<Result> CloseCurrentAccountingPeriod();
    }
}