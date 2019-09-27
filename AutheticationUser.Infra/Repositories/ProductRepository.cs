using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Repositories;
using AuthenticationUser.Infra.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationUser.Infra.Repositories
{
    public class ProductRepository : RepositoryAsync<Product>, IProductRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductsFilter(string name)
        {
            List<Product> products = await _unitOfWork._context.Products.Include("Category").ToListAsync();

            if (!string.IsNullOrEmpty(name)) {
                products = products.Where(x => x.Title.ToLower().Contains(name.ToLower())).ToList();
            }            

            return products.OrderBy(x => x.Title);
        }
    }
}
