namespace SailOnHolidays.Core.src.Entities
{
    public class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public required string? State { get; set; }
        public required string Country { get; set; }
    }
}