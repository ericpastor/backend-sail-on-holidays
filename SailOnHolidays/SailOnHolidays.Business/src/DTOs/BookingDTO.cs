using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class BookingReadDTO : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required User User { get; set; }
        public required Status Status { get; set; }
        public IEnumerable<BookingDetailsReadDTO> BookingDetails { get; } = new List<BookingDetailsReadDTO>();
    }

    public class BookingCreateDTO
    {
        public Guid? UserId { get; set; }
        public required List<BookingDetailsCreateDTO> BookingDetails { get; set; }
    }

    public class BookingUpdateDTO
    {
        public required Status Status { get; set; }
    }
}