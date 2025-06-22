namespace MyLearningPath.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ApplicationDbContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context), "No context injected");
    }

    public TRepo GetRepository<TRepo>() where TRepo : class
    {
        if (!this._repositories.ContainsKey(typeof(TRepo)))
        {
            try
            {
                var repoInstance = Activator.CreateInstance(typeof(TRepo), this._context);
                this._repositories[typeof(TRepo)] = repoInstance!;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to create an instance of repository type '{typeof(TRepo).FullName}'.", ex);
            }

        }
        return (TRepo)this._repositories[typeof(TRepo)];
    }

    public void Dispose() => this._context.Dispose();

    public async Task<int> SaveAsync() => await this._context.SaveChangesAsync();
}