using Deneme.Application.Repositories;
using Deneme.Domain.Common;
using Deneme.Domain.Entities.Common;
using Deneme.Domain.Enums;
using Deneme.Domain.ReponseEntities;
using Deneme.Infastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Infastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<BaseReponse<User>> Add(User model)
        {
            try
            {
                _dataContext.Users.Add(model);

                var result = await _dataContext.SaveChangesAsync();

                if(result > 0)
                {
                    return new BaseReponse<User>
                    {
                        Message = "Kullanıcı Başarıyla Eklendi",
                        ResultObject = model,
                        ResultStatus =ResultStatus.Success
                    };
                }
                return new BaseReponse<User>
                {
                    Message = "Kullanıcı Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = ResultStatus.Error
                };
              
            }
            catch (Exception)
            {
                return new BaseReponse<User>
                {
                    Message = "Kullanıcı Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = ResultStatus.Error
                };
            }
        }

        public async Task<BaseReponse<User>> Delete(User model)
        {
            try
            {
                _dataContext.Users.Remove(model);

                var result = await _dataContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseReponse<User>
                    {
                        Message = "Kullanıcı Başarıyla Silindi",
                        ResultStatus=ResultStatus.Success
                    };
                }
                return new BaseReponse<User>
                {
                    Message="Kullanıcı Silerken Hata Oluştu",
                    ResultObject=model,
                    ResultStatus = ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseReponse<User>
                {
                    Message = "Kullanıcı Silerken Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = ResultStatus.Error
                };
            }
        }

        public async Task<BaseReponse<User>> GetById(int id)
        {
            return new BaseReponse<User>
            {
                ResultObject = await _dataContext.Users.FirstOrDefaultAsync(t => t.id == id)
            };
        }

        public async Task<BaseReponse<User>> GetList()
        {
            return new BaseReponse<User>
            {
                ResultObjects = await _dataContext.Users.Where(t => !t.IsDeleted).ToListAsync()
            };
        }

        public async Task<BaseReponse<User>> Update(User model)
        {
            try
            {
                var currentUser = _dataContext.Users.FirstOrDefault(t => t.id == model.id);

                if(currentUser == null)
                {
                    return new BaseReponse<User>
                    {
                        Message = "Kullanıcı Bulunamadı",
                        ResultStatus = ResultStatus.Warning
                    };
                }

                currentUser.Name = model.Name;
                currentUser.SurName = model.SurName;
                currentUser.EMail = model.EMail;

                _dataContext.Users.Update(model);

                var result = await _dataContext.SaveChangesAsync();

                if(result > 0)
                {
                    return new BaseReponse<User>
                    {
                        Message = "Kullanıcı Başarıyla Güncellendi",
                        ResultObject = model,
                        ResultStatus = ResultStatus.Success
                    };
                }
                return new BaseReponse<User>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = ResultStatus.Error
                };

            }
            catch (Exception)
            {
                return new BaseReponse<User>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = ResultStatus.Error
                };
            }
        }
    }
}
