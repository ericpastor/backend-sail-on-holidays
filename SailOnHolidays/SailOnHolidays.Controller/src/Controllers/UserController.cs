using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Controller.src.Controllers
{
    public class UserController : BaseController<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        protected readonly IUserService _userService;
        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAllAsync([FromQuery] GetAllParams parameters)
        {
            return Ok(await _userService.GetAllAsync(parameters));
        }

        [Authorize]
        public override async Task<ActionResult<UserReadDTO>> GetByIdAsync([FromRoute] Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("Unable to determine user identity.");
            }

            var existingUser = await _userService.GetByIdAsync(Guid.Parse(userId));

            if (existingUser == null)
            {
                return NotFound();
            }

            var userRole = HttpContext.User.FindFirst(ClaimTypes.Role)!.Value;

            if (userId != id.ToString() && userRole != Role.Admin.ToString())
            {
                return Unauthorized();
            }

            return await _userService.GetByIdAsync(id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserReadDTO>> RegisterOneAsync([FromBody] UserCreateDTO createDTO)
        {
            return await _userService.CreateOneAsync(createDTO);
        }

        [HttpPost("owner-registration")]
        public async Task<ActionResult<OwnerReadDTO>> CreateOwnerAsync([FromBody] OwnerCreateDTO createDTO)
        {
            return await _userService.CreateOwnerAsync(createDTO);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<UserReadDTO>> GetUserProfile()
        {
            var authenticatedClaims = HttpContext.User;
            var id = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            return await _userService.GetByIdAsync(Guid.Parse(id));
        }

        [Authorize()]
        [HttpPost("change-password")]
        public async Task<ActionResult<bool>> UpdatePasswordAsync([FromBody] string originalPassword, string newPassword)
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var id = Guid.Parse(userId);

            var result = await _userService.UpdatePasswordAsync(id, originalPassword, newPassword);
            return Ok(result);
        }

        [Authorize()]
        [HttpPatch("profile")]
        public async Task<ActionResult<UserReadDTO>> UpdateOneAsync([FromBody] UserUpdateDTO updateDTO)
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var id = Guid.Parse(userId);

            return await base.UpdateOneAsync(id, updateDTO);
        }

        [Authorize()]
        [HttpPatch("owner-profile")]
        public async Task<ActionResult<UserReadDTO>> UpdateOwnerAsync([FromBody] OwnerUpdateDTO updateDTO)
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var id = Guid.Parse(userId);

            return await base.UpdateOneAsync(id, updateDTO);
        }

        [Authorize()]
        [HttpDelete("profile")]
        public async Task<ActionResult<bool>> DeleteOneAsync()
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var id = Guid.Parse(userId);

            return await base.DeleteOneAsync(id);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            return await base.DeleteOneAsync(id);
        }
    }
}