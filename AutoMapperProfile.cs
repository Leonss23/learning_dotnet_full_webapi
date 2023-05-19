using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using learning_dotnet_full_webapi.DTOs.User;
using learning_dotnet_full_webapi.Models;

namespace learning_dotnet_full_webapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserResponseDTO>();
            CreateMap<AddUserRequestDTO, User>();
        }
    }
}
