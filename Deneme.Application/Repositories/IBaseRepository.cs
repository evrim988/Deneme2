using Deneme.Domain.ReponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Application.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<BaseReponse<T>> Add(T model);
        public Task<BaseReponse<T>> Update(T model);
        public Task<BaseReponse<T>> Delete(T model);
        public Task<BaseReponse<T>> GetById(int id);
        public Task<BaseReponse<T>> GetList();
    }
}
