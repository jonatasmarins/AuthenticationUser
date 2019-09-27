using System.Threading.Tasks;

namespace AuthenticationUser.Domain.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Commited();

        ICategoryRepository categoryRepository { get; }
        IProductRepository productRepository { get; }
    }
}
