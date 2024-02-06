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

        private readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<TReadDTO> CreateOneAsync(TCreateDTO createObject)
        {
            var newObject = _mapper.Map<TCreateDTO, T>(createObject) ?? throw new ArgumentNullException(nameof(createObject), "createObject cannot be null");
            var createdObject = await _repo.CreateOneAsync(newObject);

            return _mapper.Map<T, TReadDTO>(createdObject)!;
        }

        public virtual Task<bool> DeleteOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TReadDTO>> GetAllAsync(GetAllParams parameters)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TReadDTO> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TReadDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TReadDTO> UpdateOneAsync(TUpdateDTO updateObject)
        {
            throw new NotImplementedException();
        }
    }
}