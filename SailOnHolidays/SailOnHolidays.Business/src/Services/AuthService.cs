using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Business.src.Shared;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepo _repo;
        private ITokenService _tokenService;
        public AuthService(IUserRepo userRepo, ITokenService tokenService)
        {
            _repo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<string> LoginAsync(Credentials credentials)
        {
            var foundEmail = await _repo.GetByEmailAsync(credentials.Email);
            if (foundEmail is null)
            {
                throw CustomException.NotFoundException();
            }
            var isPasswordMatch = PasswordService.VerifyPassword(credentials.Password, foundEmail.Password, foundEmail.Salt);
            if (isPasswordMatch)
            {
                return _tokenService.GenerateToken(foundEmail);
            }
            throw CustomException.NotFoundException();
        }
    }
}
