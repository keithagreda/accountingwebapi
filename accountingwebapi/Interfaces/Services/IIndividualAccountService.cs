using accountingwebapi.Dtos.IndividualAccount;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Interfaces.Services
{
    public interface IIndividualAccountService
    {
        Task<Result> CreateOrEdit(CreateOrEditIndividualAccount input);
        Task<Result<PaginatedResult<IndividualAccountDto>>> GetAllIndividualAccount(GenericSearchParam input);
        Task<Result> SeedIndividualAccount();
    }
}