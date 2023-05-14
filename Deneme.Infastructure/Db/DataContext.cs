using Deneme.Domain.Common;
using Deneme.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Deneme.Infastructure.Db
{
    public class DataContext : DbContext
    {
        //Program.cs içindeki builder.Services.AddDbContext eklerken atamanmış olan özellikleri connectionstring
        //vs. onların nesneneye atamasını yapar        
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
