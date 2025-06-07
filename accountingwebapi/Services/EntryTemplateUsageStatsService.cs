using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;

namespace accountingwebapi.Services
{
    public class EntryTemplateUsageStatsService : IEntryTemplateUsageStatsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntryTemplateUsageStatsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUsage(Ulid entryTemplateId)
        {
            var usage = await _unitOfWork.EntryTemplateUsageStats
                .FirstOrDefaultAsync(x => x.EntryTemplateId == entryTemplateId);

            if (usage != null)
            {
                usage.UsageCount += 1;
                // Not needed if ChangeTracker is active
            }
            else
            {
                usage = new EntryTemplateUsageStats
                {
                    EntryTemplateId = entryTemplateId,
                    UsageCount = 1
                };

                await _unitOfWork.EntryTemplateUsageStats.AddAsync(usage);
            }

            await _unitOfWork.CompleteAsync();
        }
    }
}
