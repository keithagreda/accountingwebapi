using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class AccountingPeriodRepository : GenericRepository<AccountingPeriod>, IAccountingPeriodRepository
    {
        public AccountingPeriodRepository(AcctgContext context) : base(context)
        {
        }
    }


}
