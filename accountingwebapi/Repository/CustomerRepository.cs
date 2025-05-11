using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Models.App;
using Repository;

namespace accountingwebapi.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AcctgContext context) : base(context)
        {
        }
    }


}
