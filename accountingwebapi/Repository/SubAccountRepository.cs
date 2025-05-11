using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class SubAccountRepository : GenericRepository<SubAccount>, ISubAccountRepository
    {
        public SubAccountRepository(AcctgContext context) : base(context)
        {
        }
    }


}
