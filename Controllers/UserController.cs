using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.DTOs.User;
using learning_dotnet_full_webapi.Models;
using learning_dotnet_full_webapi.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace learning_dotnet_full_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetUserResponseDTO>>>> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDTO>>> GetSingle(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDTO>>> PostUser(
            AddUserRequestDTO user
        )
        {
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDTO>>> UpdateUser(
            UpdateUserRequestDTO updatedUser
        )
        {
            return Ok(await _userService.UpdateUser(updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserResponseDTO>>> DeleteUser(int id)
        {
            return Ok(await _userService.DeleteUserById(id));
        }
    }
}
