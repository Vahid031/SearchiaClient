using Newtonsoft.Json;

namespace Searchia.Models;

public class DocumentsInfo
{
    [JsonProperty("successfulDocIds")]
    public List<string> SuccessfulDocIds { get; set; }

    [JsonProperty("failedDocs")]
    public object FailedDocs { get; set; }

    [JsonProperty("storeCount")]
    public int StoreCount { get; set; }

    [JsonProperty("updateCount")]
    public int UpdateCount { get; set; }

    [JsonProperty("deleteCount")]
    public int DeleteCount { get; set; }
}