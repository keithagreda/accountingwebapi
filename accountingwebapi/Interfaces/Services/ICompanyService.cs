using accountingwebapi.Dtos.Company;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Result<Ulid>> CreateOrEdit(CreateOrEditCompanyDto input);
        Task<Result<PaginatedResult<CompanyDto>>> GetAll(GetCompanyInput input);
    }
}