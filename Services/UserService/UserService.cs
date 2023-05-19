using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using learning_dotnet_full_webapi.DTOs.User;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserResponseDTO>>> AddUser(
            AddUserRequestDTO newUser
        )
        {
            var mappedUser = _mapper.Map<User>(newUser);
            if (User.List.Count > 0)
                mappedUser.Id = (User.List.Max(user => user.Id) + 1);
            User.List.Add(mappedUser);

            var serviceResponse = new ServiceResponse<List<GetUserResponseDTO>>
            {
                Data = _mapper.Map<List<GetUserResponseDTO>>(User.List)
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserResponseDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserResponseDTO>>
            {
                Data = _mapper.Map<List<GetUserResponseDTO>>(User.List)
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDTO>> GetUserById(int id)
        {
            var user = User.List.FirstOrDefault(user => user.Id == id);
            var serviceResponse = new ServiceResponse<GetUserResponseDTO>
            {
                Data = _mapper.Map<GetUserResponseDTO>(user)
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDTO>> UpdateUser(
            UpdateUserRequestDTO updatedUser
        )
        {
            var user = User.List.FirstOrDefault(user => user.Id == updatedUser.Id);
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;

            var serviceResponse = new ServiceResponse<GetUserResponseDTO>
            {
                Data = _mapper.Map<GetUserResponseDTO>(user)
            };
            return serviceResponse;
        }
    }
}
