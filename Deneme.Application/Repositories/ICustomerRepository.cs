using Deneme.Domain.Common;
using Deneme.Application.Repositories;

namespace Deneme.Application.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        //public Task<bool> CustomerExist();
    }
}
