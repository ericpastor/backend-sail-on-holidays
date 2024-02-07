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

        public Task<T?> CreateOneAsync(T createObject)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(T deleteObject)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(GetAllParams parameters)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<T?> UpdateOneAsync(T updateObject)
        {
            throw new NotImplementedException();
        }
    }
}