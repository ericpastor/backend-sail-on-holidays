using SailOnHolidays.Core.src.Parameters;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
    {
        Task<IEnumerable<TReadDTO>> GetAllAsync(GetAllParams parameters);
        Task<TReadDTO> GetByIdAsync(Guid Id);
        Task<TReadDTO> GetByNameAsync(string name);
        Task<TReadDTO> CreateOneAsync(TCreateDTO createObject);
        Task<TReadDTO> UpdateOneAsync(TUpdateDTO updateObject);
        Task<bool> DeleteOneAsync(Guid id);
    }
}