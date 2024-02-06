using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Controller.src.Controllers
{
    public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}