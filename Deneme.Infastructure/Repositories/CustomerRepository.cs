using Deneme.Application.Repositories;
using Deneme.Domain.Common;
using Deneme.Domain.ReponseEntities;
using Deneme.Infastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Deneme.Infastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<BaseReponse<Customer>> Add(Customer model)
        {
            try
            {
                _dataContext.Customers.Add(model);

                var result = await _dataContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseReponse<Customer>
                    {
                        Message = "Müşteri Ekleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Ekleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }

        public async Task<BaseReponse<Customer>> Delete(Customer model)
        {
            try
            {
                _dataContext.Customers.Remove(model);

                var result = await _dataContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseReponse<Customer>
                    {
                        Message = "Müşteri Silme Başarılı",
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Silme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }

        public async Task<BaseReponse<Customer>> GetById(int id)
        {
            return new BaseReponse<Customer>
            {
                ResultObject = await _dataContext.Customers.FirstOrDefaultAsync(t => t.id == id)
            };
        }

        public async Task<BaseReponse<Customer>> GetList()
        {

            return new BaseReponse<Customer>
            {
                ResultObjects = await _dataContext.Customers.Where(t => !t.IsDeleted).ToListAsync()
            };
        }

        public async Task<BaseReponse<Customer>> Update(Customer model)
        {
            try
            {
                var currentCustomer = _dataContext.Customers.FirstOrDefault(t => t.id == model.id);

                if (currentCustomer == null)
                {
                    return new BaseReponse<Customer>
                    {
                        Message = "Müşteri Bulunamadı",
                        ResultStatus = Domain.Enums.ResultStatus.Warning
                    };
                }

                currentCustomer.Adress = model.Adress;
                currentCustomer.Name = model.Name;
                currentCustomer.Surname = model.Surname;

                _dataContext.Customers.Update(model);

                var result = await _dataContext.SaveChangesAsync();

                if (result > 0)
                {
                    return new BaseReponse<Customer>
                    {
                        Message = "Müşteri Güncelleme Başarılı",
                        ResultObject = model,
                        ResultStatus = Domain.Enums.ResultStatus.Success
                    };
                }

                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
            catch (Exception)
            {
                return new BaseReponse<Customer>
                {
                    Message = "Müşteri Güncelleme Sırasında Hata Oluştu",
                    ResultObject = model,
                    ResultStatus = Domain.Enums.ResultStatus.Error
                };
            }
        }
    }
}

