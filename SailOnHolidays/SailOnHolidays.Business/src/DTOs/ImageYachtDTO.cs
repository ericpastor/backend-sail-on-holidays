using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class ImageYachtReadDTO : BaseEntity
    {
        public Guid YachtId { get; set; }
        public required byte[] Data { get; set; }
        public required string IamgeYachtBase64Data { get; set; }
    }

    public class ImageYachtCreateDTO
    {
        public Guid YachtId { get; set; }
        public required byte[] Data { get; set; }
    }
    public class ImageYachtUpdateDTO
    {
        public Guid Id { get; set; }
        public byte[]? Data { get; set; }
    }
}