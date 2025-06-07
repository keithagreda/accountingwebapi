using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class EntryTemplateUsageStatsRepository : GenericRepository<EntryTemplateUsageStats>, IEntryTemplateUsageStatsRepository
    {
        public EntryTemplateUsageStatsRepository(AcctgContext context) : base(context)
        {
        }
    }
}
