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
        public required AddressReadDTO Address { get; set; }
        public required AvatarReadDTO Avatar { get; set; }
    }

    public class UserRegisterDTO
    {
        public Role Role { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required AddressCreateDTO Address { get; set; }
        public required AvatarCreateDTO Avatar { get; set; }
    }

    public class UserCreateDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public required AddressCreateDTO Address { get; set; }
        public required AvatarCreateDTO Avatar { get; set; }
    }

    public class UserUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public AddressUpdateDTO? Address { get; set; }
        public AvatarUpdateDTO? Avatar { get; set; }
    }


}