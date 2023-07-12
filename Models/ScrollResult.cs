using Newtonsoft.Json;

namespace Searchia.Models;

public class ScrollResult
{
    [JsonProperty("numberOfHits")]
    public int NumberOfHits { get; set; }

    [JsonProperty("numberOfChunks")]
    public int NumberOfChunks { get; set; }

    [JsonProperty("docIdToFieldMap")]
    public object DocIdToFieldMap { get; set; }
}