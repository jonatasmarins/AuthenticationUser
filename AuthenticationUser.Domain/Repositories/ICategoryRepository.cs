using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Repositories.Generic;

namespace AuthenticationUser.Domain.Repositories
{
    public interface ICategoryRepository : IRepositoryAsync<Category>
    {
    }
}
