using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationUser.Domain.Repositories
{
    public interface IProductRepository : IRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> GetProductsFilter(string name);
    }
}
