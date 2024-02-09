using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Controller.src.Utilities;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.Controller.src.Controllers
{
    public class AvatarController : BaseController<Avatar, AvatarReadDTO, AvatarCreateDTO, AvatarUpdateDTO>
    {
        protected readonly IAvatarService _avatarService;
        public AvatarController(IAvatarService avatarService) : base(avatarService)
        {
            _avatarService = avatarService;
        }

        [Authorize]
        [HttpPost("upload-avatar")]
        public async Task<ActionResult<AvatarReadDTO>> UploadAvatarAsync([FromForm] AvatarForm avatarCreate)
        {
            var authenticatedClaims = HttpContext.User;
            var id = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            byte[] imageData = await FileHelper.ConvertIFormFileToByteArrayAsync(avatarCreate.AvatarImage);

            var avatarCreateObject = new AvatarCreateDTO
            {
                UserId = Guid.Parse(id),
                Data = imageData
            };

            var uploadedAvatar = await _avatarService.UploadAvatar(avatarCreateObject);
            return uploadedAvatar;
        }

        [Authorize]
        [HttpPatch("change-avatar")]
        public async Task<ActionResult<AvatarReadDTO>> UpdateAvatarAsync([FromForm] AvatarForm avatarCreate)
        {
            var authenticatedClaims = HttpContext.User;
            var id = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            var userId = Guid.Parse(id);

            byte[] imageData = await FileHelper.ConvertIFormFileToByteArrayAsync(avatarCreate.AvatarImage);

            var avatarUpdateObject = new AvatarUpdateDTO
            {
                UserId = Guid.Parse(id),
                Data = imageData
            };

            var updatedAvatar = await _avatarService.UpdateOneAsync(userId, avatarUpdateObject);

            return updatedAvatar;
        }

    }

    public class AvatarForm
    {
        public required IFormFile AvatarImage { get; set; }
    }
}