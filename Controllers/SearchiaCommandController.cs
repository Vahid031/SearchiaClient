using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Searchia.Services;

namespace Searchia.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchiaCommandController : ControllerBase
{
    private readonly ISearchiaCommandClient _searchiaClient;
    private const string IndexName = "person";

    public SearchiaCommandController(ISearchiaCommandClient searchiaClient)
    {
        _searchiaClient = searchiaClient;
    }

    [HttpPost("create-doc")]
    public async Task<IActionResult> StoreIndex([FromBody] PersonCommand model)
    {
        var result = await _searchiaClient.CreateDoc(IndexName, model);

        return Ok(result);
    }

    [HttpPost("create-docs")]
    public async Task<IActionResult> StoreIndices([FromBody] List<PersonCommand> model)
    {
        var result = await _searchiaClient.CreateDocs(IndexName, model);

        return Ok(result);
    }

    [HttpPut("update-doc")]
    public async Task<IActionResult> UpdateIndex([FromBody] PersonCommand model)
    {
        var result = await _searchiaClient.UpdateDoc(IndexName, model);

        return Ok(result);
    }

    [HttpPut("update-docs")]
    public async Task<IActionResult> UpdateIndices([FromBody] List<PersonCommand> model)
    {
        var result = await _searchiaClient.UpdateDocs(IndexName, model);

        return Ok(result);
    }

    [HttpPut("increment")]
    public async Task<IActionResult> Increment(string id, uint value)
    {
        var result = await _searchiaClient.Increment(IndexName, id, "age", value);

        return Ok(result);
    }

    [HttpPut("decrement")]
    public async Task<IActionResult> Decrement(string id, uint value)
    {
        var result = await _searchiaClient.Decrement(IndexName, id, "age", value);

        return Ok(result);
    }

    [HttpDelete("delete-doc")]
    public async Task<IActionResult> DeleteDocument(string id)
    {
        var result = await _searchiaClient.DeleteDoc(IndexName, id);

        return Ok(result);
    }

    [HttpDelete("delete-docs")]
    public async Task<IActionResult> DeleteDocuments(List<string> ids)
    {
        var result = await _searchiaClient.DeleteDocs(IndexName, ids);

        return Ok(result);
    }

    [HttpPut("click")]
    public async Task<IActionResult> Click(string id, string queryId)
    {
        var result = await _searchiaClient.Click(IndexName, id, queryId, 1, "09214545");

        return Ok(result);
    }

    [HttpPut("cart")]
    public async Task<IActionResult> Cart(string id)
    {
        var result = await _searchiaClient.Cart(IndexName, id);

        return Ok(result);
    }

    [HttpPut("cart-with-query")]
    public async Task<IActionResult> Cart(string id, string queryId)
    {
        var result = await _searchiaClient.Cart(IndexName, id, queryId, "09214545");

        return Ok(result);
    }



}

public abstract class BaseQueryDoc
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_click")]
    public int Click { get; set; }

    [JsonProperty("_cart")]
    public int Cart { get; set; }
}

public class PersonQuery : BaseQueryDoc
{
    [JsonProperty("firstname")]
    public string FirstName { get; set; }

    [JsonProperty("lastname")]
    public string LastName { get; set; }

    [JsonProperty("job")]
    public string Job { get; set; }

    [JsonProperty("age")]
    public int Age { get; set; }
}


public abstract class BaseCommandDoc
{
    [JsonProperty("_id")]
    public string Id { get; set; }
}

public class PersonCommand : BaseCommandDoc
{
    [JsonProperty("firstname")]
    public string FirstName { get; set; }

    [JsonProperty("lastname")]
    public string LastName { get; set; }

    [JsonProperty("job")]
    public string Job { get; set; }

    [JsonProperty("age")]
    public int Age { get; set; }
}