using AutoMapper;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class BaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> where T : BaseEntity
    {
        protected readonly IBaseRepo<T> _repo;

        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TReadDTO>> GetAllAsync(GetAllParams parameters)
        {
            return _mapper.Map<IEnumerable<T>, IEnumerable<TReadDTO>>(await _repo.GetAllAsync(parameters))!;
        }

        public virtual async Task<TReadDTO> CreateOneAsync(TCreateDTO createObject)
        {
            var newObject = _mapper.Map<TCreateDTO, T>(createObject) ?? throw new ArgumentNullException(nameof(createObject), "createObject cannot be null");
            var createdObject = await _repo.CreateOneAsync(newObject);

            return _mapper.Map<T, TReadDTO>(createdObject)!;
        }

        public virtual async Task<bool> DeleteOneAsync(Guid id)
        {
            var deleteObject = await _repo.GetByIdAsync(id) ?? throw new NotImplementedException();
            return await _repo.DeleteOneAsync(deleteObject);
        }

        public virtual async Task<TReadDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<T, TReadDTO>(await _repo.GetByIdAsync(id)) ?? throw new NotImplementedException();
        }

        public virtual async Task<TReadDTO> GetByNameAsync(string name)
        {
            return _mapper.Map<T, TReadDTO>(await _repo.GetByNameAsync(name)) ?? throw new NotImplementedException();
        }

        public virtual async Task<TReadDTO> UpdateOneAsync(Guid id, TUpdateDTO updateObject)
        {
            var objectToUpdate = await _repo.GetByIdAsync(id) ?? throw new NotImplementedException();

            var objectUpdated = _mapper.Map(updateObject, objectToUpdate) ?? throw new NotImplementedException();

            return _mapper.Map<T, TReadDTO>(await _repo.UpdateOneAsync(objectUpdated)) ?? throw new NotImplementedException();
        }
    }
}