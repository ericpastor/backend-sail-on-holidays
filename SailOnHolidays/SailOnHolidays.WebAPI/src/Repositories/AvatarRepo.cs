using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.WebAPI.src.Database;

namespace SailOnHolidays.WebAPI.src.Repositories
{
    public class AvatarRepo : BaseRepo<Avatar>, IAvatarRepo
    {
        public AvatarRepo(DatabaseContext database) : base(database)
        { }

        public async Task<Avatar> UploadAvatar(Avatar avatar)
        {
            await _data.AddAsync(avatar);
            await _databaseContext.SaveChangesAsync();

            return avatar;
        }
    }
}