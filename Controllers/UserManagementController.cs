using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.Models;
using learning_dotnet_full_webapi.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace learning_dotnet_full_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userManagementService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingle(int id)
        {
            return Ok(await _userManagementService.GetUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            return Ok(await _userManagementService.AddUser(user));
        }
    }
}
