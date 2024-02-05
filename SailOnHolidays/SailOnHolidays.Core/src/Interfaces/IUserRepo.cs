using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Core.src.Interfaces
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}