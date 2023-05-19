using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using learning_dotnet_full_webapi.Data;
using learning_dotnet_full_webapi.DTOs.User;
using learning_dotnet_full_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace learning_dotnet_full_webapi.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetUserResponseDTO>>> AddUser(
            AddUserRequestDTO newUser
        )
        {
            var serviceResponse = new ServiceResponse<List<GetUserResponseDTO>>();
            var mappedUser = _mapper.Map<User>(newUser);

            _context.Users.Add(mappedUser);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<List<GetUserResponseDTO>>(_context.Users);
            serviceResponse.Success = true;
            serviceResponse.Message = "User added successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserResponseDTO>>> DeleteUserById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserResponseDTO>>();

            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<List<GetUserResponseDTO>>(
                await _context.Users.ToListAsync()
            );
            serviceResponse.Success = true;
            serviceResponse.Message = "User deleted successfully";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserResponseDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetUserResponseDTO>>();

            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to fetch users list.";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<List<GetUserResponseDTO>>(users);
            serviceResponse.Success = true;
            serviceResponse.Message = "Fetched users list successfully.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDTO>();

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<GetUserResponseDTO>(user);
            serviceResponse.Success = true;
            serviceResponse.Message = "Fetched user successfully.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserResponseDTO>> UpdateUser(
            UpdateUserRequestDTO updateRequest
        )
        {
            var serviceResponse = new ServiceResponse<GetUserResponseDTO>();

            var userUpdate = await _context.Users.FindAsync(updateRequest.Id);

            if (userUpdate == null)
            {
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            userUpdate.Username = updateRequest.Username;
            userUpdate.Password = updateRequest.Password;

            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetUserResponseDTO>(userUpdate);
            serviceResponse.Success = true;
            serviceResponse.Message = "User updated successfully";
            return serviceResponse;
        }
    }
}
