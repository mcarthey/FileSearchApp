using Nest;

public class FileIndexer
{
    private readonly IElasticClient _elasticClient;

    public FileIndexer(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    // Other methods using _elasticClient
}
