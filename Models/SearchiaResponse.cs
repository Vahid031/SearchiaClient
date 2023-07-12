using Newtonsoft.Json;

namespace Searchia.Models;

public class SearchiaResponse
{
    [JsonProperty("statusType")]
    public string StatusType { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }

    public bool IsSucceeded => "SUCCESS".Equals(StatusType, StringComparison.OrdinalIgnoreCase);
}

public class SearchiaResponse<T> : SearchiaResponse
{
    [JsonProperty("entity")] public T Entity { get; set; }
}