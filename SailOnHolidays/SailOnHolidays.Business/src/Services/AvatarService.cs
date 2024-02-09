using AutoMapper;
using SailOnHolidays.Business.src.DTOs;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class AvatarService : BaseService<Avatar, AvatarReadDTO, AvatarCreateDTO, AvatarUpdateDTO>, IAvatarService
    {
        protected readonly IAvatarRepo _avatarRepo;
        private readonly IUserService _userService;
        public AvatarService(IAvatarRepo avatarRepo, IUserService userService, IMapper mapper) : base(avatarRepo, mapper)
        {
            _avatarRepo = avatarRepo;
            _userService = userService;
        }

        public async Task<AvatarReadDTO> UploadAvatar(AvatarCreateDTO avatar)
        {
            await _userService.GetByIdAsync(avatar.UserId);

            var avatarEntity = _mapper.Map<AvatarCreateDTO, Avatar>(avatar) ?? throw CustomException.NullException("Updated user cannot be null");
            var uploadedAvatar = await _avatarRepo.UploadAvatar(avatarEntity);

            return _mapper.Map<Avatar, AvatarReadDTO>(uploadedAvatar) ?? throw CustomException.MappingErrorException("Something went wrong mapping the result");
        }

        public override async Task<AvatarReadDTO> UpdateOneAsync(Guid id, AvatarUpdateDTO updateDTO)
        {
            var originalEntity = await _avatarRepo.GetByIdAsync(id) ?? throw CustomException.NotFoundException("User not found");

            var updatedAvatar = _mapper.Map(updateDTO, originalEntity) ?? throw CustomException.NullException("Updated user cannot be null");
            updatedAvatar.UpdatedAt = DateTime.UtcNow;

            var result = await _avatarRepo.UpdateOneAsync(updatedAvatar);

            return _mapper.Map<Avatar, AvatarReadDTO>(result) ?? throw CustomException.MappingErrorException("Something went wrong mapping the result");
        }

        public async Task<UserReadDTO> GetByUserIdAsync(Guid userId)
        {
            var user = await _userService.GetByIdAsync(userId) ?? throw CustomException.NotFoundException("Avatar not found");
            return user;
        }
    }
}