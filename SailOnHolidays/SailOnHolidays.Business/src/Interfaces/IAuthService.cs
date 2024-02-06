using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IAuthService
    {

        Task<string> Login(Credentials credentials);
    }
}