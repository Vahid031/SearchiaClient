using Newtonsoft.Json;

namespace Searchia.Models;

public class BannedExpression
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("rule")]
    public BannedExpressionEnum Rule { get; set; }
}