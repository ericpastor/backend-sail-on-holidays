namespace SailOnHolidays.Core.src.Entities
{
    public class Avatar : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public byte[] Data { get; set; }
    }
}