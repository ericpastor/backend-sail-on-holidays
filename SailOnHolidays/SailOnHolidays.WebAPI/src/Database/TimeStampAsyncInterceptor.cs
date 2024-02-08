using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SailOnHolidays.Core.src.Entities;

namespace SailOnHolidays.WebAPI.src.Database
{
    public class TimeStampAsyncInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var changedData = eventData.Context?.ChangeTracker.Entries();
            var updatedEntries = changedData?.Where(entity => entity.State == EntityState.Modified);
            var addedEntries = changedData?.Where(entity => entity.State == EntityState.Added);

            foreach (var e in updatedEntries!)
            {
                if (e.Entity is BaseEntity entity)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            foreach (var e in addedEntries!)
            {
                if (e.Entity is BaseEntity entity)
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}