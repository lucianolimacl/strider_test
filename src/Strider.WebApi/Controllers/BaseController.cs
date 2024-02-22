using Microsoft.AspNetCore.Mvc;
using Strider.Common;

namespace Strider.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult FilterResult<T>(Result<T> result)
        {

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
