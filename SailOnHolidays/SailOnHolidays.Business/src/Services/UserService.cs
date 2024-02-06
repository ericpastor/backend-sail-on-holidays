using AutoMapper;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;

namespace SailOnHolidays.Business.src.Services
{
    public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        protected readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public Task<UserReadDTO?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(Guid UserId, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}