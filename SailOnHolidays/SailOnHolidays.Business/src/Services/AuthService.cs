using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Business.src.Shared;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepo _userRepo;
        private ITokenService _tokenService;
        public AuthService(IUserRepo userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<string> Login(Credentials credentials)
        {
            var foundEmail = await _userRepo.GetByEmailAsync(credentials.Email);
            if (foundEmail is null)
            {
                throw new NotImplementedException();
            }
            var isPasswordMatch = PasswordService.VerifyPassword(credentials.Password, foundEmail.Password, foundEmail.Salt);
            if (isPasswordMatch)
            {
                return _tokenService.GenerateToken(foundEmail);
            }
            throw new NotImplementedException();
        }
    }
}