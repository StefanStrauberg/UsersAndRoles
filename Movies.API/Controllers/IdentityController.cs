using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers
{
    [Authorize]
    public class IdentityController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
            => new JsonResult(from x in User.Claims select new { x.Type, x.Value});
    }
}