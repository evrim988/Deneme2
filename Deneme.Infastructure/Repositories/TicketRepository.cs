using Deneme.Application.Repositories;
using Deneme.Domain.ReponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Infastructure.Repositories
{
    public class TicketRepository : ITaskRepository
    {
        public Task<BaseReponse<Task>> Add(Task model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<Task>> Delete(Task model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<Task>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<Task>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<Task>> Update(Task model)
        {
            throw new NotImplementedException();
        }
    }
}
