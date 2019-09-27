using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Category;
using AuthenticationUser.Domain.Models.Response.Category;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationUser.Domain.Services
{
    public interface ICategoryApplicationService
    {
        Task<ResultResponse> Create(string title);
        Task<ResultResponse> Delete(CategoryModelRequest categoryId);
        Task<ResultResponse> Update(CategoryModelRequest title);
        Task<ResultResponseObject<IEnumerable<CategoryModelResponse>>> GetAll();
    }
}
