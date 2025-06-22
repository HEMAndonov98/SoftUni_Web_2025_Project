namespace MyLearningPath.Infrastructure.Repository.Interface;

public interface IEfRepository<TEntity>
 where TEntity : class
{
    Task<TEntity?> GetById(object id);
    IQueryable<TEntity> All();

    IQueryable<TEntity> AllAsNoTracking();

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    TEntity SoftDeleteAsync(TEntity entity);

}
