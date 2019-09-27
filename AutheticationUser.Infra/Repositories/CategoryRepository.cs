using AuthenticationUser.Domain.Entities;
using AuthenticationUser.Domain.Repositories;
using AuthenticationUser.Infra.Repositories.Generic;

namespace AuthenticationUser.Infra.Repositories
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

