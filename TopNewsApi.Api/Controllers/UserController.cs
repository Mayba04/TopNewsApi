﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TopNewsApi.Core.DTOs.Token;
using TopNewsApi.Core.DTOs.User;
using TopNewsApi.Core.Interfaces;
using TopNewsApi.Core.Services;
using TopNewsApi.Core.Validation.User;

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


        [HttpPost("Create")]
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

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(DeleteUserDTO model)
        {
            var res = await _userService.GetUserByIdAsync(model.Id);
            if (res.Success)
            {
                return Ok(res.Message);
            }
            return Ok(res.Message);
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

    }
}
