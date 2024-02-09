using System.Text;
using AutoMapper;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Business.src.Shared;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>, IUserService
    {
        protected readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<OwnerReadDTO?> GetOwnerByIdAsync(Guid id)
        {
            return _mapper.Map<User, OwnerReadDTO>(await _userRepo.GetByIdAsync(id)) ?? throw CustomException.MappingErrorException("Mapping to UserReadDTO failed.");
        }
        public async Task<UserReadDTO?> GetByEmailAsync(string email)
        {
            return _mapper.Map<User, UserReadDTO>(await _userRepo.GetByEmailAsync(email)) ?? throw CustomException.MappingErrorException("Mapping to UserReadDTO failed.");
        }

        public async Task<OwnerReadDTO?> GetOwnerByEmailAsync(string email)
        {
            return _mapper.Map<User, OwnerReadDTO>(await _userRepo.GetByEmailAsync(email)) ?? throw CustomException.MappingErrorException("Mapping to UserReadDTO failed.");
        }

        public override async Task<UserReadDTO> CreateOneAsync(UserCreateDTO createObject)
        {

            if (createObject == null)
            {
                throw CustomException.NullException("Object cannot be null");
            }
            else if (await _userRepo.GetByEmailAsync(createObject.Email) != null)
            {
                throw new NotImplementedException();
            }
            PasswordService.HashPassword(createObject.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDTO, User>(createObject) ?? throw CustomException.MappingErrorException("Mapping to User failed.");
            user.Password = hashedPassword;
            user.Salt = salt;

            user.Role = Role.Customer;

            var createdUser = await _userRepo.CreateOneAsync(user);

            if (createdUser == null)
            {
                throw new InvalidOperationException("User creation failed.");
            }
            return _mapper.Map<User, UserReadDTO>(createdUser)!;
        }

        public async Task<OwnerReadDTO> CreateOwnerAsync(OwnerCreateDTO createObject)
        {

            if (createObject == null)
            {
                throw CustomException.NullException("Object cannot be null");
            }
            else if (await _userRepo.GetByEmailAsync(createObject.Email) != null)
            {
                throw CustomException.NotFoundException("");
            }
            PasswordService.HashPassword(createObject.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<OwnerCreateDTO, User>(createObject) ?? throw CustomException.MappingErrorException("Mapping to User failed.");
            user.Password = hashedPassword;
            user.Salt = salt;

            user.Role = Role.Owner;

            var createdUser = await _userRepo.CreateOwnerAsync(user);

            if (createdUser == null)
            {
                throw CustomException.NullException("User cannot be null. User creation failed.");
            }
            return _mapper.Map<User, OwnerReadDTO>(createdUser)!;
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, string originalPassword, string newPassword)
        {
            var user = await _userRepo.GetByIdAsync(userId) ?? throw CustomException.NotFoundException("User not found");


            var isPasswordMatch = PasswordService.VerifyPassword(originalPassword, user.Password, user.Salt);

            if (!isPasswordMatch)
            {
                throw CustomException.MatchingException("Password is not matching");
            }

            PasswordService.HashPassword(newPassword, out string salt, out byte[] hashedPassword);

            byte[] saltString = Encoding.UTF8.GetBytes(salt);

            user.Password = hashedPassword.ToString()!;
            user.Salt = saltString;
            user.UpdatedAt = DateTime.Now;

            await _userRepo.UpdateOneAsync(user);

            return true;
        }

        public override async Task<UserReadDTO> UpdateOneAsync(Guid id, UserUpdateDTO updateDTO)
        {
            var originalEntity = await _userRepo.GetByIdAsync(id) ?? throw CustomException.NotFoundException("User not found");

            if (updateDTO.Email == originalEntity.Email)
            {
                throw CustomException.ConflictException();
            }

            var updatedEntity = _mapper.Map(updateDTO, originalEntity) ?? throw CustomException.NullException("Updated user cannot be null");
            updatedEntity.UpdatedAt = DateTime.UtcNow;

            var result = await _repo.UpdateOneAsync(updatedEntity);

            return _mapper.Map<User, UserReadDTO>(result) ?? throw CustomException.MappingErrorException("Something went wrong mapping the result");
        }
    }
}