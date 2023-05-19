using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learning_dotnet_full_webapi.DTOs.User;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserResponseDTO>>> GetAll();
        Task<ServiceResponse<GetUserResponseDTO>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserResponseDTO>>> AddUser(AddUserRequestDTO newUser);
        Task<ServiceResponse<GetUserResponseDTO>> UpdateUser(UpdateUserRequestDTO updatedUser);
        Task<ServiceResponse<List<GetUserResponseDTO>>> DeleteUserById(int id);
    }
}
