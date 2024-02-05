using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class AvatarReadDTO : BaseEntity
    {
        public required byte[] Data { get; set; }
        public required string AvatarBase64Value { get; set; }
    }
    public class AvatarCreateDTO
    {
        public Guid UserId { get; set; }
        public required byte[] Data { get; set; }
    }
    public class AvatarUpdateDTO
    {
        public Guid UserId { get; set; }
        public byte[]? Data { get; set; }
    }
}