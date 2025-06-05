using accountingwebapi.Dtos.JournalEntry;
using accountingwebapi.Dtos.Result;
using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Interfaces.Services
{
    public interface IJournalEntryService
    {
        Task<Result> CreateOrEdit(CreateOrEditJournalEntryDto input);
        Task<Result<PaginatedResult<JournalEntryDto>>> GetAll(GetJournalEntryInput input);
    }
}