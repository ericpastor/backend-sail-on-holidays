using System.Text.Json.Serialization;

namespace SailOnHolidays.Core.src.Entities
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public required Status Status { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Status
    {
        ReservationUnpaid,
        ReservationPaid
    }
}