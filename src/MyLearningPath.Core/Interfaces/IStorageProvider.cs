namespace MyLearningPath.Core.Interfaces;

public interface IStorageProvider
{
    Task SaveFileAsync(string fileName, FileStream fileStream);
    Task<FileStream?> GetFileAsync(string fileName);
    Task DeleteFileAsync(string fileName);
}
