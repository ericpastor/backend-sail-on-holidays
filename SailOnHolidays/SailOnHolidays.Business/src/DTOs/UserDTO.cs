using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.DTOs
{
    public class UserReadDTO : BaseEntity
    {
        public Role Role { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public string? State { get; set; }
        public required string Country { get; set; }
        public AvatarReadDTO? Avatar { get; set; }
    }

    public class OwnerReadDTO : UserReadDTO
    {
        public required string BankAccountNumber { get; set; }
        public IEnumerable<Yacht>? Yachts { get; set; }
    }

    public class UserCreateDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public string? State { get; set; }
        public required string Country { get; set; }
    }

    public class OwnerCreateDTO : UserCreateDTO
    {
        public required string BankAccountNumber { get; set; }
    }

    public class UserUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? BankAccountNumber { get; set; }
    }

    public class OwnerUpdateDTO : UserUpdateDTO
    {
        public new string? BankAccountNumber { get; set; }
    }
}