using Newtonsoft.Json;
using Searchia.Controllers;

namespace Searchia.Models;

public class SearchResult<TResult> where TResult : BaseQueryDoc
{
    [JsonProperty("totalHits")]
    public int TotalHits { get; set; }

    [JsonProperty("searchTime")]
    public int SearchTime { get; set; }

    [JsonProperty("queryId")]
    public string QueryId { get; set; }

    [JsonProperty("facets")]
    public string Facets { get; set; }

    [JsonProperty("results")]
    public List<QueryResult<TResult>> Result { get; set; }
}