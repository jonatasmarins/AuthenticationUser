using AuthenticationUser.Domain.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationUser.WebApi.Controllers.Base
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(IResultResponse resultResponse = null)
        {
            if (resultResponse != null && resultResponse.Success)
            {
                return Ok(resultResponse);
            }
            else
            {
                return BadRequest(resultResponse.ErrorMessages);
            }
        }
    }
}
