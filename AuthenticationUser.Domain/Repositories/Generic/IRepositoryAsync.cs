using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationUser.Domain.Repositories.Generic
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task Create(T obj);
        Task<IEnumerable<T>> Get();
        Task Delete(T obj);
        Task Update(T obj);
    }
}
