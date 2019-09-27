using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Product;
using AuthenticationUser.Domain.Models.Response.Product;
using AuthenticationUser.Domain.Services;
using AuthenticationUser.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : BaseController
    {
        private readonly IProductApplicationService _productApplicationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productApplicationService"></param>
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }


        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="name"></param>        
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(string name)
        {
            ResultResponseObject<IEnumerable<ProductModelResponse>> result = await _productApplicationService.GetProductsFilter(name);

            return Response(result);
        }


        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]ProductModelRequest request)
        {
            ResultResponse result = await _productApplicationService.Create(request);

            return Response(result);
        }


        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody]ProductModelRequest request)
        {
            ResultResponse result = await _productApplicationService.Update(request);

            return Response(result);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete([FromQuery]ProductModelRequest request)
        {
            ResultResponse result = await _productApplicationService.Delete(request);

            return Response(result);
        }
    }
}