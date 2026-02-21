using AskingKitten.Application.FilesStorage;

namespace AskingKitten.Infrastructure.S3;

public class S3Provider : IFilesProvider
{
    public Task<string> UploadAsync(Stream fileStream, string key, string bucket) => throw new NotImplementedException();
}