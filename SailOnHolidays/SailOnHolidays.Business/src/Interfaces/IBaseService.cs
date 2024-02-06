using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Business.src.Interfaces
{
    public interface IBaseService<T, TReadDTO, TCreateDTO, TUpdateDTO>
    {
        Task<IEnumerable<TReadDTO>> GetAllAsync(GetAllParams parameters);
        Task<TReadDTO> GetByIdAsync(Guid Id);
        Task<TReadDTO> GetByNameAsync(string name);
        Task<TReadDTO> CreateOneAsync(TCreateDTO createDTO);
        Task<TReadDTO> UpdateOneAsync(Guid id, TUpdateDTO updateDTO);
        Task<bool> DeleteOneAsync(Guid id);
    }
}