using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.WebAPI.src.Database;

namespace SailOnHolidays.WebAPI.src.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {

        public UserRepo(DatabaseContext database) : base(database)
        {
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(Guid UserId, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}