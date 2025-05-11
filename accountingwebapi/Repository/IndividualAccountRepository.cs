using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class IndividualAccountRepository : GenericRepository<IndividualAccount>, IIndividualAccountRepository
    {
        public IndividualAccountRepository(AcctgContext context) : base(context)
        {
        }
    }


}
