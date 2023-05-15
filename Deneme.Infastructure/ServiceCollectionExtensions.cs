using Deneme.Application.Repositories;
using Deneme.Infastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Deneme.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MyRepository(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();


            return services;
        }
    }
}
