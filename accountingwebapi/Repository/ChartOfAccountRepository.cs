using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.Application;
using Repository;

namespace accountingwebapi.Repository
{
    public class ChartOfAccountRepository : GenericRepository<ChartOfAccount>, IChartOfAccountRepository
    {
        public ChartOfAccountRepository(AcctgContext context) : base(context)
        {
        }
    }


}
