using AutoMapper;
using jobsity_chat_app.DTO;
using jobsity_chat_app.DTO.Users;
using jobsity_chat_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobsity_chat_app
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<AddUserDto, User>();
        }
    }
}
