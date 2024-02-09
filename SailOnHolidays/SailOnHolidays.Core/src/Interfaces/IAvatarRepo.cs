using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Core.src.Interfaces
{
    public interface IAvatarRepo : IBaseRepo<Avatar>
    {
        public Task<Avatar> UploadAvatar(Avatar avatar);
    }
}