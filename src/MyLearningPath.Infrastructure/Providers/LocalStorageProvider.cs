using MyLearningPath.Core.Interfaces;

namespace MyLearningPath.Infrastructure.Providers;

public class LocalStorageProvider : IStorageProvider
{
    private readonly string _storagePath;
    private readonly int _buffer = 65536;

    public LocalStorageProvider(string storagePath)
    {
        this._storagePath = storagePath;
        Directory.CreateDirectory(_storagePath);
    }
    public Task DeleteFileAsync(string fileName)
    {
        string filePath = Path.Combine(this._storagePath, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return Task.CompletedTask;
    }

    public async Task<FileStream?> GetFileAsync(string fileName)
    {
        string filePath = Path.Combine(this._storagePath, fileName);
        if (!File.Exists(filePath))
        {
            throw new ArgumentException();
        }

        return await Task.Run(() => File.OpenRead(filePath));
    }

    public async Task SaveFileAsync(string fileName, FileStream fileStream)
    {
        string filePath = Path.Combine(_storagePath, fileName);
        using (var outputStream = File.Create(filePath))
        {
            await fileStream.CopyToAsync(outputStream, _buffer);
        }
    }
}
