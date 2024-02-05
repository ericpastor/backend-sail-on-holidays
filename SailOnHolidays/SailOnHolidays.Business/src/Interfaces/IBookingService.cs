using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IBookingService : IBaseService<Booking, BookingReadDTO, BookingCreateDTO, BookingUpdateDTO>
    { }
}