using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class JournalEntryRepository : GenericRepository<JournalEntry>, IJournalEntryRepository
    {
        public JournalEntryRepository(AcctgContext context) : base(context)
        {
        }
    }


}
