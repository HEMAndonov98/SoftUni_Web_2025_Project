using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Infrastructure.Query_Interceptors;

public class SafeDeleteInterceptor : SaveChangesInterceptor
{

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context == null)
        {
            return base.SavingChangesAsync(
                eventData, result, cancellationToken);
        }

        IEnumerable<EntityEntry<BaseEfModel<string>>> entries =
            eventData
                .Context
                .ChangeTracker
                .Entries<BaseEfModel<string>>()
                .Where(e => e.State == EntityState.Deleted);


        foreach (EntityEntry<BaseEfModel<string>> entry in entries)
        {
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
            entry.Entity.DeletedAt = DateTime.UtcNow;
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);

    }
}
