using Deneme.Domain.Common;
using Deneme.Persistence.BaseRepostitory;

namespace Deneme.Persistence.Repositories.CustomerRepository.Concrete
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        //public Task<bool> CustomerExist();
    }
}
