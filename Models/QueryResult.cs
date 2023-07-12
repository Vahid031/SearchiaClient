using Newtonsoft.Json;
using Searchia.Controllers;

namespace Searchia.Models;

public class QueryResult<TResult> where TResult : BaseQueryDoc
{
    [JsonProperty("indexName")]
    public string IndexName { get; set; }

    [JsonProperty("documentId")]
    public string DocumentId { get; set; }

    [JsonProperty("documentInfo")]
    public string DocumentInfo { get; set; }

    [JsonProperty("beforePersonalizationPosition")]
    public int BeforePersonalizationPosition { get; set; }

    [JsonProperty("pinned")]
    public bool Pinned { get; set; }

    [JsonProperty("contentRankingDetails")]
    public string ContentRankingDetails { get; set; }

    [JsonProperty("source")]
    public TResult Source { get; set; }

    [JsonProperty("highlight")]
    public object Highlight { get; set; }

    [JsonProperty("subGroupDocs")]
    public string SubGroupDocs { get; set; }

    [JsonProperty("relationalIndicesSource")]
    public string RelationalIndicesSource { get; set; }
}