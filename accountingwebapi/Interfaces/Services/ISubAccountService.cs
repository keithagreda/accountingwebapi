using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SubAccount;

namespace accountingwebapi.Interfaces.Services
{
    public interface ISubAccountService
    {
        Task<Result> CreateOrEdit(CreateOrEditSubAccountDto input);
        Task<Result<List<GetSubAccountForViewDto>>> GetAll();
    }
}