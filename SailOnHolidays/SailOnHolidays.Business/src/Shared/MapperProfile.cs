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

            CreateMap<User, OwnerReadDTO>();
            CreateMap<OwnerCreateDTO, User>();
            CreateMap<OwnerUpdateDTO, User>();

            CreateMap<Avatar, AvatarReadDTO>();
            CreateMap<AvatarCreateDTO, Avatar>();
            CreateMap<AvatarUpdateDTO, Avatar>();
        }
    }
}