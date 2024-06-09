using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FileSearchController : ControllerBase
{
    private readonly IElasticClient _elasticClient;
    private readonly ILogger<FileSearchController> _logger;

    public FileSearchController(IElasticClient elasticClient, ILogger<FileSearchController> logger)
    {
        _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        _logger.LogInformation("Ping request received.");
        var pingResponse = _elasticClient.Ping();
        if (pingResponse.IsValid)
        {
            return Ok("Elasticsearch connection is valid");
        }
        return StatusCode(500, "Elasticsearch connection is invalid");
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            _logger.LogWarning("Search query is empty.");
            return BadRequest("Query cannot be empty");
        }

        _logger.LogInformation($"Search request received with query: {query}");

        try
        {
            var searchResponse = await _elasticClient.SearchAsync<dynamic>(s => s
                .Index("files")
                .Query(q => q
                    .QueryString(qs => qs
                        .Query(query)
                    )
                )
            );

            if (searchResponse == null)
            {
                _logger.LogError("Search response is null.");
                return StatusCode(500, "Search request failed");
            }

            if (searchResponse.IsValid)
            {
                _logger.LogInformation("Search request succeeded.");
                return Ok(searchResponse.Documents);
            }

            _logger.LogError($"Search request failed: {searchResponse.ServerError}");
            return StatusCode(500, "Search request failed");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception occurred during search: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
