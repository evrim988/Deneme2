using Deneme.Persistence.Repositories.CustomerRepository.Abstract;
using Deneme.Persistence.Repositories.CustomerRepository.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Deneme.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection EvriminRepostiyoryleri(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();


            return services;
        }
    }
}
