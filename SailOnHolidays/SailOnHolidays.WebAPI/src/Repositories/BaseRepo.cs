using Microsoft.EntityFrameworkCore;
using SailOnHolidays.Core.src;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Shared;
using SailOnHolidays.WebAPI.src.Database;

namespace SailOnHolidays.WebAPI.src.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _data;
        protected readonly DatabaseContext _databaseContext;

        public BaseRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _data = _databaseContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(GetAllParams parameters)
        {
            return await _data.AsNoTracking().Skip(parameters.Offset).Take(parameters.Limit).ToArrayAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _data.FindAsync(id);
        }

        public virtual async Task<T?> GetByNameAsync(string name)
        {
            return await _data.FindAsync(name);
        }
        public virtual async Task<T?> CreateOneAsync(T createObject)
        {
            _data.Add(createObject);
            await _databaseContext.SaveChangesAsync();
            return createObject;
        }

        public virtual async Task<bool> DeleteOneAsync(T deleteObject)
        {
            _data.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<T?> UpdateOneAsync(T updatedObject)
        {
            _data.Update(updatedObject);
            await _databaseContext.SaveChangesAsync();
            return updatedObject;
        }
    }
}