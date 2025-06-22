using Microsoft.EntityFrameworkCore;

using MyLearningPath.Infrastructure.Repository.Interface;

namespace MyLearningPath.Infrastructure.Repository;

public class BaseRepository<TEntity> : IEfRepository<TEntity>
where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbSet<TEntity> dbSet)
    {
        this._dbSet = dbSet;
    }

    public async Task AddAsync(TEntity entity) => await this._dbSet.AddAsync(entity);

    public IQueryable<TEntity> AllAsNoTracking() => this._dbSet.AsNoTracking();

    public IQueryable<TEntity> All() => this._dbSet;
    
    public TEntity SoftDeleteAsync(TEntity entity)
    {
        this._dbSet.Remove(entity);
        return entity;
    }

    public void Update(TEntity entity) => this._dbSet.Update(entity);

    public async Task<TEntity?> GetById(object id) => await this._dbSet.FindAsync(id);
    
    //TODO Implement in specificRepository
    // public async Task<TEntity?> RestoreAsync(TEntity entity)
    // {
    //     var entry = await this._dbSet
    //         .IgnoreQueryFilters()
    //         .FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsDeleted == true);
    //
    //     if (entry == null)
    //     {
    //         throw new ArgumentNullException();
    //     }
    //
    //     entry.IsDeleted = false;
    //     entry.DeletedAt = null;
    //     entry.LastModifiedAt = DateTime.UtcNow;
    //
    //     this._dbSet.Update(entry);
    //     return entry;
    // }
}
