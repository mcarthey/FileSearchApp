using Nest;
using System.IO;
using System.Threading.Tasks;

public class FileIndexer
{
    private readonly ElasticClient _client;

    public FileIndexer(ElasticClient client)
    {
        _client = client;
    }

    public async Task IndexFile(string filePath)
    {
        var fileContent = await File.ReadAllTextAsync(filePath);
        var fileMetadata = new
        {
            Path = filePath,
            Content = fileContent,
            FileName = Path.GetFileName(filePath)
        };

        await _client.IndexDocumentAsync(fileMetadata);
    }
}
