using Microsoft.EntityFrameworkCore;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.Core.src.Shared;
using SailOnHolidays.WebAPI.src.Database;

namespace SailOnHolidays.WebAPI.src.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {

        public UserRepo(DatabaseContext database) : base(database)
        { }

        public override async Task<IEnumerable<User>> GetAllAsync(GetAllParams parameters)
        {
            return await _data.Include(u => u.Avatar).Skip(parameters.Offset).Take(parameters.Limit).ToArrayAsync();
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _data.Include(u => u.Avatar).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _data.Include(u => u.Avatar).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> CreateOwnerAsync(User createUser)
        {
            _data.Add(createUser);
            await _databaseContext.SaveChangesAsync();
            return createUser;
        }
    }
}