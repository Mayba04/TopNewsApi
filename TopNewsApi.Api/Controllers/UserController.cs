using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TopNewsApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok("User: Bill");
        }
    }
}
