using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IAvatarService : IBaseService<Avatar, AvatarReadDTO, AvatarCreateDTO, AvatarUpdateDTO>
    {
        public Task<AvatarReadDTO> UploadAvatar(AvatarCreateDTO avatar);
    }
}