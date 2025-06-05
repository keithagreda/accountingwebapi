using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class EntryTemplateRepository : GenericRepository<EntryTemplate>, IEntryTemplateRepository
    {
        public EntryTemplateRepository(AcctgContext context) : base(context)
        {
        }
    }


}
