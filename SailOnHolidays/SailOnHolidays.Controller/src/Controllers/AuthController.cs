using Microsoft.AspNetCore.Mvc;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<string> LoginAsync(Credentials credentials)
        {
            return await _service.LoginAsync(credentials);
        }
    }
}
