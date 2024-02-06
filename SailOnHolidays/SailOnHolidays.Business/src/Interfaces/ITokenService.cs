using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}