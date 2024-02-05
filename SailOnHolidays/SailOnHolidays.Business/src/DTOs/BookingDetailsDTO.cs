namespace SailOnHolidays.Business.src.DTOs
{
    public class BookingDetailsReadDTO
    {
        public required YachtReadDTO Yacht { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class BookingDetailsCreateDTO
    {
        public Guid YachtId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}