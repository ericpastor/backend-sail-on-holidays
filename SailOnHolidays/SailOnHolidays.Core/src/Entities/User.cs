using System.Text.Json.Serialization;

namespace SailOnHolidays.Core.src.Entities
{
    public class User : BaseEntity
    {
        public Enum Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public Avatar Avatar { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Role
    {
        Admin,
        Owner,
        Customer
    }
}
