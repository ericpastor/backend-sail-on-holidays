namespace SailOnHolidays.Core.src.Entities
{
    public class BookingDetails : TimeStamp
    {
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public Guid YachtId { get; set; }
    }
}