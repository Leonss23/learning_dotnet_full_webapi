using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public class UserManagementService : IUserManagementService
    {
        public async Task<List<User>> AddUser(User newUser)
        {
            User.List.Add(newUser);
            return User.List;
        }

        public async Task<List<User>> GetAll()
        {
            return User.List;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = User.List.FirstOrDefault(user => user.Id == id);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }
    }
}
