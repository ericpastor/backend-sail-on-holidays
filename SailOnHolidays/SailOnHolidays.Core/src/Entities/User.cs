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
        public required Address Address { get; set; }
        public required Avatar Avatar { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Role
    {
        Admin,
        Owner,
        Customer
    }
}
