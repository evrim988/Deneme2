using Deneme.Domain.ReponseEntities;

namespace Deneme.Persistence.BaseRepostitory
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
