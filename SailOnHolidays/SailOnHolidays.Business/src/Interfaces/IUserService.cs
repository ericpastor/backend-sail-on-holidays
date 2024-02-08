using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        Task<UserReadDTO?> GetByEmailAsync(string email);
        Task<bool> UpdatePasswordAsync(Guid userId, string originalPassword, string newPassword);
        Task<OwnerReadDTO> CreateOwnerAsync(OwnerCreateDTO ownerCreate);
    }
}