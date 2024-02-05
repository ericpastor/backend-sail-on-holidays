using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class AddressReadDTO : BaseEntity
    {
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public required string? State { get; set; }
        public required string Country { get; set; }
    }

    public class AddressCreateDTO
    {
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public required string? State { get; set; }
        public required string Country { get; set; }
    }

    public class AddressUpdateDTO
    {
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }
}