using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class CustomerContactDetailRepository : GenericRepository<CustomerContactDetail>, ICustomerContactDetailRepository
    {
        public CustomerContactDetailRepository(AcctgContext context) : base(context)
        {
        }
    }


}
