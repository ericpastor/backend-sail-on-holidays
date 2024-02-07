using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<Avatar, AvatarReadDTO>();
            CreateMap<AvatarCreateDTO, Avatar>();
            CreateMap<AvatarUpdateDTO, Avatar>();
        }
    }
}