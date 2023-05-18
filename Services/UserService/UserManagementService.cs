using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public class UserManagementService : IUserManagementService
    {
        public async Task<ServiceResponse<List<User>>> AddUser(User newUser)
        {
            User.List.Add(newUser);

            var serviceResponse = new ServiceResponse<List<User>> { Data = User.List };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = User.List;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var user = User.List.FirstOrDefault(user => user.Id == id);
            if (user == null)
                throw new Exception("User not found");

            var serviceResponse = new ServiceResponse<User>();
            serviceResponse.Data = user;
            return serviceResponse;
        }
    }
}
