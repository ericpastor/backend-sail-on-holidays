using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;

namespace SailOnHolidays.Business.src.Services
{
    public class OrderService : BaseService<Booking, BookingReadDTO, BookingCreateDTO, BookingUpdateDTO>, IBookingService
    {
        protected readonly IBookingRepo _bookingRepo;

        public OrderService(IBookingRepo bookingRepo) : base(bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
    }
}