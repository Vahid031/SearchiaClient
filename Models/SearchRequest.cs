using Newtonsoft.Json;

namespace Searchia.Models;

public class SearchRequest
{
    [JsonProperty("requestId")]
    public string RequestId { get; set; }

    [JsonProperty("indexName")]
    public required string IndexName { get; set; }

    [JsonProperty("query")]
    public string Query { get; set; }

    [JsonProperty("optionalFilters")]
    public string OptionalFilters { get; set; }

    [JsonProperty("filters")]
    public string Filters { get; set; }

    [JsonProperty("sorts")]
    public string Sorts { get; set; }

    [JsonProperty("facets")]
    public string Facets { get; set; }

    [JsonProperty("userToken")]
    public string UserToken { get; set; }

    [JsonProperty("exactMatch")]
    public bool ExactMatch { get; set; }

    [JsonProperty("groupingEnabled")]
    public bool GroupingEnabled { get; set; }

    [JsonProperty("subGroupingEnabled")]
    public bool SubGroupingEnabled { get; set; }

    [JsonProperty("docInfo")]
    public bool DocInfo { get; set; }

    [JsonProperty("fl")]
    public List<string> Fields { get; set; }

    [JsonProperty("sfl")]
    public List<string> SearchableFieldsList { get; set; }

    [JsonProperty("analyticsTags")]
    public List<string> AnalyticsTags { get; set; }

    [JsonProperty("from")]
    public int From { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lon")]
    public double Longitude { get; set; }
}