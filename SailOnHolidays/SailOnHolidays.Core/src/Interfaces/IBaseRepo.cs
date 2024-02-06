using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;

namespace SailOnHolidays.Core.src
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(GetAllParams parameters);
        Task<T?> GetByIdAsync(Guid Id);
        Task<T?> GetByNameAsync(string name);
        Task<T?> CreateOneAsync(T createObject);
        Task<T?> UpdateOneAsync(T updateObject);
        Task<bool> DeleteOneAsync(T deleteObject);
    }
}