using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public interface IUserManagementService
    {
        Task<List<User>> GetAll();
        Task<User> GetUserById(int id);
        Task<List<User>> AddUser(User newUser);
    }
}
