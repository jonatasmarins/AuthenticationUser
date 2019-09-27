using AuthenticationUser.Domain.Repositories;
using AuthenticationUser.Domain.Repositories.UnitOfWork;
using AuthenticationUser.Infra.Contexts;
using AuthenticationUser.Infra.Repositories;
using System.Threading.Tasks;

namespace AuthenticationUser.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Commited()
        {
            await _context.SaveChangesAsync();
        }


        #region Repositories


        public ICategoryRepository categoryRepository { get => new CategoryRepository(this); }
        public IProductRepository productRepository { get => new ProductRepository(this); }

        #endregion


        #region Dispose

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        #endregion
    }
}
