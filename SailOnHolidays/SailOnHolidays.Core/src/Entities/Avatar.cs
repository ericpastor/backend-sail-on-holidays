namespace SailOnHolidays.Core.src.Entities
{
    public class Avatar : BaseEntity
    {
        public Guid UserId { get; set; }
        public required byte[] Data { get; set; }
    }
}