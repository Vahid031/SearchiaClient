using Newtonsoft.Json;

namespace Searchia.Models;

public class DocumentInfo
{
    [JsonProperty("docId")]
    public required string DocId { get; set; }

    [JsonProperty("type")]
    public required string Type { get; set; }
}