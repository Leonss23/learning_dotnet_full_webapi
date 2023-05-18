using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public interface IUserManagementService
    {
        Task<ServiceResponse<List<User>>> GetAll();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<ServiceResponse<List<User>>> AddUser(User newUser);
    }
}
