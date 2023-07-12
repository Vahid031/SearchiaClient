using Newtonsoft.Json;

namespace Searchia.Models;

public class SuggestResult
{
    [JsonProperty("topQuerySuggestions")]
    public List<string> TopQuerySuggestions { get; set; }

    [JsonProperty("topQuerySuggestionsIncludeCategory")]
    public List<string> TopQuerySuggestionsIncludeCategory { get; set; }

    [JsonProperty("searchTime")]
    public int SearchTime { get; set; }
}