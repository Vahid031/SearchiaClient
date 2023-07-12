using Newtonsoft.Json;

namespace Searchia.Models;

public class FederatedSearchIndexParam
{
    [JsonProperty("indexName")]
    public required string IndexName { get; set; }

    [JsonProperty("optionalFilters")]
    public string OptionalFilters { get; set; }

    [JsonProperty("filters")]
    public string Filters { get; set; }

    [JsonProperty("facetFilters")]
    public string FacetFilters { get; set; }

    [JsonProperty("sorts")]
    public string Sorts { get; set; }

    [JsonProperty("facets")]
    public string Facets { get; set; }

    [JsonProperty("enablePersonalization")]
    public bool EnablePersonalization { get; set; }

    [JsonProperty("exactMatch")]
    public bool ExactMatch { get; set; }

    [JsonProperty("groupingEnabled")]
    public bool GroupingEnabled { get; set; }

    [JsonProperty("subGroupingEnabled")]
    public bool SubGroupingEnabled { get; set; }

    [JsonProperty("docInfo")]
    public bool DocInfo { get; set; }

    [JsonProperty("orSearchEnabled")]
    public bool OrSearchEnabled { get; set; }

    [JsonProperty("qpEnabled")]
    public bool QpEnabled { get; set; }

    [JsonProperty("personalizationImpact")]
    public int PersonalizationImpact { get; set; }

    [JsonProperty("subGroupMaxSize")]
    public int SubGroupMaxSize { get; set; }

}