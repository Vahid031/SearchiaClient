using Microsoft.AspNetCore.Mvc;
using Searchia.Models;
using Searchia.Services;

namespace Searchia.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchiaBannedExpressionController : ControllerBase
{
    private readonly ISearchiaBannedExpressionClient _searchiaClient;
    private const string IndexName = "person-offer";

    public SearchiaBannedExpressionController(ISearchiaBannedExpressionClient searchiaClient)
    {
        _searchiaClient = searchiaClient;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(BannedExpressionEnum rule, string text)
    {
        var result = await _searchiaClient.Add(IndexName, rule, text);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(string id, BannedExpressionEnum rule, string text)
    {
        var result = await _searchiaClient.Update(IndexName, id, rule, text);

        return Ok(result);
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var result = await _searchiaClient.Get(IndexName);

        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _searchiaClient.Delete(IndexName, id);

        return Ok(result);
    }
}