using AuthenticationUser.Domain.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationUser.Infra.Repositories.Generic
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private UnitOfWork _unitOfWork;
        private DbSet<T> _repositoryT;

        public RepositoryAsync(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositoryT = unitOfWork._context.Set<T>();
        }

        public async Task Create(T obj)
        {
            await _repositoryT.AddAsync(obj);
            await _unitOfWork._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _repositoryT.ToListAsync<T>();
        }

        public async Task Delete(T obj)
        {
            _repositoryT.Remove(obj);
            await _unitOfWork._context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {

            _repositoryT.Update(obj);
            await _unitOfWork._context.SaveChangesAsync();
        }
    }
}
