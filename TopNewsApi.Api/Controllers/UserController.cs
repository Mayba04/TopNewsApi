using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopNewsApi.Core.Interfaces;
using TopNewsApi.Core.Services;

namespace TopNewsApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDashdoardAccessService _IPService;
        public UserController(UserService userService, ICategoryService categoryService, IDashdoardAccessService iPService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _IPService = iPService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _userService.GetAllAsync()).Payload);
        }
    }
}
