using Microsoft.AspNetCore.Mvc;
using Nest;

[ApiController]
[Route("api/[controller]")]
public class FileSearchController : ControllerBase
{
    private readonly IElasticClient _elasticClient;

    public FileSearchController(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        var response = _elasticClient.Ping();
        if (response.IsValid)
        {
            return Ok("Elasticsearch connection is valid");
        }
        return StatusCode(500, "Elasticsearch connection is invalid");
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("The query field is required.");
        }

        var response = _elasticClient.Search<object>(s => s
            .Index("files")
            .Query(q => q
                .QueryString(qs => qs
                    .Query(query)
                )
            )
        );

        if (!response.IsValid)
        {
            return BadRequest(response.OriginalException.Message);
        }

        return Ok(response.Documents);
    }
}
