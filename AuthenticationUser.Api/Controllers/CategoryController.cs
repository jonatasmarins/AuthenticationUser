using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Category;
using AuthenticationUser.Domain.Models.Response.Category;
using AuthenticationUser.Domain.Services;
using AuthenticationUser.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApplicationService _categoryApplicationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryApplicationService"></param>
        public CategoryController(ICategoryApplicationService categoryApplicationService)
        {
            _categoryApplicationService = categoryApplicationService;
        }


        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get()
        {
            ResultResponseObject<IEnumerable<CategoryModelResponse>> result = await _categoryApplicationService.GetAll();

            return Response(result);
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(string title)
        {
            ResultResponse result = await _categoryApplicationService.Create(title);

            return Response(result);
        }


        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody]CategoryModelRequest request)
        {
            ResultResponse result = await _categoryApplicationService.Update(request);

            return Response(result);
        }


        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete([FromBody]CategoryModelRequest request)
        {
            ResultResponse result = await _categoryApplicationService.Delete(request);

            return Response(result);
        }
    }
}