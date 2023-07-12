using Newtonsoft.Json;
using Searchia.Controllers;

namespace Searchia.Models;

public class RequestResult<TResult> where TResult : BaseQueryDoc
{
    [JsonProperty("requestId")]
    public string RequestId { get; set; }

    [JsonProperty("statusType")]
    public string StatusType { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("entity")]
    public SearchResult<TResult> Entity { get; set; }
}