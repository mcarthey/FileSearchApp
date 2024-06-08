using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FileSearchController : ControllerBase
{
    private readonly ElasticClient _client;
    private readonly FileIndexer _fileIndexer;

    public FileSearchController(ElasticClient client, FileIndexer fileIndexer)
    {
        _client = client;
        _fileIndexer = fileIndexer;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchFiles([FromQuery] string query)
    {
        var response = await _client.SearchAsync<dynamic>(s => s
            .Query(q => q
                .MultiMatch(m => m
                    .Query(query)
                    .Fields(f => f
                        .Field("FileName")
                        .Field("Content")
                    )
                )
            )
        );

        return Ok(response.Documents);
    }

    [HttpPost("index")]
    public async Task<IActionResult> IndexFile([FromBody] FileIndexRequest request)
    {
        await _fileIndexer.IndexFile(request.FilePath);
        return Ok();
    }
}

public class FileIndexRequest
{
    public string FilePath { get; set; }
}
