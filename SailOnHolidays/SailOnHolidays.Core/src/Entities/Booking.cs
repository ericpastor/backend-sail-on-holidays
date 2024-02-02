namespace SailOnHolidays.Core.src.Entities
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Enum Status { get; set; }
    }
}