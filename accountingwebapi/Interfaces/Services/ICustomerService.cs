using accountingwebapi.Dtos.Customer;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Result<Ulid>> CreateOrEdit(CreateOrEditCustomerDto input);
        Task<Result<PaginatedResult<GetCustomerOutput>>> GetAll(GetCustomerInput input);
    }
}