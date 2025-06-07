using accountingwebapi.Dtos.Result;
using accountingwebapi.Interfaces.Repositories;

namespace accountingwebapi.Services
{
    public class EntryTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntryTemplateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Ulid>> CreateOrEdit()

    }
}
