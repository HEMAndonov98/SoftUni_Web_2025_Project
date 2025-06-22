using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Infrastructure.Repository.Interface;

public interface EfRepository<TEntity>
 where TEntity : BaseEfModel<string>
{
    Task<TEntity> GetById(string Id);
    IQueryable<TEntity> All();

    IQueryable<TEntity> AllAsNoTracking();

    Task AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    TEntity SoftDeleteAsync(TEntity entity);

    Task<int> SaveChangesAsync();

    Task<TEntity?> RestoreAsync(TEntity entity);
}
