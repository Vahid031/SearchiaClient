using Newtonsoft.Json;

namespace Searchia.Models;

public class UserHistoryResult
{
    [JsonProperty("queries")]
    List<string> Queries { get; set; }
}