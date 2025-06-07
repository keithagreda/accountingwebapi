using accountingwebapi.Dtos.EntryTemplate;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Interfaces.Services
{
    public interface IEntryTemplateService
    {
        Task<Result<Ulid>> CreateOrEdit(CreateOrEditEntryTemplateDto input);
        Task<Result<PaginatedResult<GetEntryTemplateDto>>> GetAll(GetEntryTemplateInputDto input);
    }
}