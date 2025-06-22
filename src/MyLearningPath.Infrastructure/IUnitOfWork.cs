namespace MyLearningPath.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveAsync();

    TRepo GetRepository<TRepo>() where TRepo : class;
}