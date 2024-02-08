using System.Text.Json.Serialization;

namespace SailOnHolidays.Core.src.Entities
{
    public class User : BaseEntity
    {

        public required Role Role { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required byte[] Salt { get; set; }
        public required string Phone { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public string? State { get; set; }
        public required string Country { get; set; }
        public Avatar? Avatar { get; set; }
        public string? BankAccountNumber { get; set; }
        public IEnumerable<Yacht>? Yachts { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Role
    {
        Admin,
        Owner,
        Customer
    }
}
