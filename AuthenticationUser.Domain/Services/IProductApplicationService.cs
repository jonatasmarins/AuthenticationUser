using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Product;
using AuthenticationUser.Domain.Models.Response.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationUser.Domain.Services
{
    public interface IProductApplicationService
    {
        Task<ResultResponse> Create(ProductModelRequest request);
        Task<ResultResponse> Delete(ProductModelRequest request);
        Task<ResultResponse> Update(ProductModelRequest request);
        Task<ResultResponseObject<IEnumerable<ProductModelResponse>>> GetAll();
        Task<ResultResponseObject<IEnumerable<ProductModelResponse>>> GetProductsFilter(string title);
    }
}
