using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Core.src;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Services
{
    public class BaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> : IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO> where T : BaseEntity
    {
        protected readonly IBaseRepo<T> _repo;

        public BaseService(IBaseRepo<T> repo)
        {
            _repo = repo;
        }

        public virtual Task<TReadDTO> CreateOneAsync(TCreateDTO createObject)
        {
            throw new NotImplementedException();
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