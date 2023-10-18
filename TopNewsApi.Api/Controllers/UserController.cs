using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TopNewsApi.Core.DTOs.Token;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Interfaces;
using TopNewsApi.Core.Services;
using TopNewsApi.Core.Validation.User;

namespace TopNewsApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IDashdoardAccessService _IPService;
        private readonly RolesService _rolesService;
        private readonly RoleManager<IdentityRole> _rolesManager;

        public UserController(UserService userService, ICategoryService categoryService, IDashdoardAccessService iPService, RolesService rolesService, RoleManager<IdentityRole> rolesManager)
        {
            _userService = userService;
            _categoryService = categoryService;
            _IPService = iPService;
            _rolesService = rolesService;
            _rolesManager = rolesManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _userService.GetAllAsync()));
        }


        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAlRoles()
        {
            return Ok((await _rolesService.GetAllRolesAsync()));
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var result = await _userService.GetUserByIdAsync(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("CreatUser")]
        public async Task<IActionResult> Create(CreateUserDTO model)
        {
            var validator = new CreateUserValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _userService.CreateUserAsync(model);
                if (result.Success)
                {
                    return Ok(result.Payload);
                }

                return Ok(result.Payload);

            }
            return Ok(validationResult.Errors[0]);

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync([FromBody] string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(UpdateUserDTO model)
        {
            var validator = new UpdateUserValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse result = await _userService.EditUserAsync(model);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return Ok(result.Message);
            }
 
            return Ok(validationResult.Errors[0]);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto model)
        {
            var validator = new LoginUserValid();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);
                return Ok(result);
            }

            return BadRequest(validationResult.Errors[0].ToString());
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut(string userId)
        {
            await _userService.DeleteAllRefreshTokenByUserIdAsync(userId);
            await _userService.SignOutAsync();
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] TokenRequestDto model)
        {
            var result = await _userService.RefreshTokenAsync(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _userService.ConfirmEmailAsync(userId, token);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }

            var result = await _userService.ForgotPasswordAsync(email);

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
