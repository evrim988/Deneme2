using Deneme.Application.Repositories;
using Deneme.Domain.Common;
using Deneme.Domain.Entities.Common;
using Deneme.Domain.ReponseEntities;
using Deneme.Infastructure.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Infastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<BaseReponse<Project>> Add(Project model)
        {
            try
            {
                _dataContext.Projects.Add(model);

                var result=await _dataContext.SaveChangesAsync();

                if(result>0)
                {
                    return new BaseReponse<Project>
                    {
                        Message = "Proje Ekleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success,
                    };
                }

                return new BaseReponse<Project>
                {
                    Message = "Proje Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Success,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseReponse<Project>> Delete(Project model)
        {
            try
            {
                _dataContext.Projects.Remove(model);

                var result = await _dataContext.SaveChangesAsync();

                if( result > 0 )
                {
                    return new BaseReponse<Project>
                    {
                        Message = "Müşteri Silme Başarılı",
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }
                return new BaseReponse<Project>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BaseReponse<Project>> GetById(int id)
        {
            return new BaseReponse<Project>
            {
                ResultObject = await _dataContext.Projects.FirstOrDefaultAsync(t => t.id == id)
            };
        }

        public async Task<BaseReponse<Project>> GetList()
        {
            return new BaseReponse<Project>
            {
                ResultObjects = await _dataContext.Projects.Where(t => !t.IsDeleted).ToListAsync()
            };
        }

        public async Task<BaseReponse<Project>> Update(Project model)
        {
            try
            {
                var projectCustomer = _dataContext.Projects.FirstOrDefault(t => t.id == model.id);

                if (projectCustomer == null)
                {
                    return new BaseReponse<Project>
                    {
                        Message = "Müşteri Bulunamadı",
                        ResultStatus = Domain.Enums.ResultStatus.Warning
                    };
                }

                projectCustomer.ProjeAdı = model.ProjeAdı;
                projectCustomer.ProjeAçıklaması = model.ProjeAçıklaması;

                _dataContext.Projects.Update(model);

                var result = await _dataContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseReponse<Project>
                    {
                        Message = "Müşteri Güncelleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseReponse<Project>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
