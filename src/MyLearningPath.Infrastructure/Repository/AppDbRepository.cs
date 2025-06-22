using Microsoft.EntityFrameworkCore;

using MyLearningPath.Core.Models.BaseModel;
using MyLearningPath.Infrastructure.Repository.Interface;

namespace MyLearningPath.Infrastructure.Repository;

public class AppDbRepository<TEntity> : EfRepository<TEntity>
where TEntity : BaseEfModel<string>
{
    private ApplicationDbContext _dbContext { get; set; }

    private DbSet<TEntity> _dbSet { get; set; }

    public AppDbRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
        this._dbSet = this._dbContext.Set<TEntity>();
    }

    public Task AddAsync(TEntity entity) => this._dbSet.AddAsync(entity).AsTask();

    public IQueryable<TEntity> AllAsNoTracking() => this._dbSet.AsNoTracking();

    public IQueryable<TEntity> All() => this._dbSet;

    public Task<int> SaveChangesAsync() => this._dbContext.SaveChangesAsync();

    public TEntity SoftDeleteAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }

        this._dbSet.Remove(entity);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = this._dbContext.Entry(entity);
        var original = await this._dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == entity.Id);

        if (original == null)
        {
            throw new ArgumentNullException();
        }

        if (entry.State == EntityState.Detached)
        {
            this._dbSet.Attach(entity);
        }

        entity.LastModifiedAt = DateTime.UtcNow;
        entry.State = EntityState.Modified;

        return original;
    }

    public async Task<TEntity> GetById(string Id)
    {
        var entry = await this._dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == Id);

        if (entry == null)
        {
            throw new ArgumentNullException();
        }
        return entry;
    }

    public async Task<TEntity?> RestoreAsync(TEntity entity)
    {
        var entry = await this._dbSet
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(e => e.Id == entity.Id && e.IsDeleted == true);

        if (entry == null)
        {
            throw new ArgumentNullException();
        }

        entry.IsDeleted = false;
        entry.DeletedAt = null;
        entry.LastModifiedAt = DateTime.UtcNow;

        this._dbSet.Update(entry);
        return entry;
    }
}
