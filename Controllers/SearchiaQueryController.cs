using Microsoft.AspNetCore.Mvc;
using Searchia.Models;
using Searchia.Services;

namespace Searchia.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchiaQueryController : ControllerBase
{
    private readonly ISearchiaQueryClient _searchiaClient;
    private const string IndexName = "person";

    public SearchiaQueryController(ISearchiaQueryClient searchiaClient)
    {
        _searchiaClient = searchiaClient;
    }

    [HttpGet("search-query")]
    public async Task<IActionResult> Search(string query)
    {
        var result = await _searchiaClient.Search<PersonQuery>(IndexName, query);

        return Ok(result);
    }

    [HttpPost("search-bulk")]
    public async Task<IActionResult> Search([FromBody] List<SearchRequest> model)
    {
        var result = await _searchiaClient.Search<PersonQuery>(model);

        return Ok(result);
    }

    [HttpPost("search-federate")]
    public async Task<IActionResult> Search([FromBody] FederatedSearchRequest model)
    {
        var result = await _searchiaClient.Search<PersonQuery>(model);

        return Ok(result);
    }

    [HttpGet("search-doc")]
    public async Task<IActionResult> SearchByDocId(string docId)
    {
        var result = await _searchiaClient.SearchByDocId<PersonQuery>(IndexName, docId);

        return Ok(result);
    }

    [HttpGet("suggest")]
    public async Task<IActionResult> Suggest(string query)
    {
        var result = await _searchiaClient.Suggest(new SuggestRequest
        {
            IndexName = "person-offer",
            Query = query
        });

        return Ok(result);
    }

    [HttpGet("history")]
    public async Task<IActionResult> History()
    {
        var result = await _searchiaClient.UserHistory(IndexName, "09214545", 10);

        return Ok(result);
    }

    [HttpGet("scroll")]
    public async Task<IActionResult> Scroll(string query)
    {
        var result = await _searchiaClient.Scroll(new ScrollRequest
        {
            ChunkNo = 2,
            IndexName = IndexName,
            Query = query
        });

        return Ok(result);
    }
}