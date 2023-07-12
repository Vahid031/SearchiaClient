using Newtonsoft.Json;

namespace Searchia.Models;

public class FederatedSearchRequest
{
    [JsonProperty("query")]
    public string Query { get; set; }

    [JsonProperty("userToken")]
    public string UserToken { get; set; }

    [JsonProperty("analyticsTagsArray")]
    public List<string> AnalyticsTags { get; set; }

    [JsonProperty("from")]
    public int From { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lon")]
    public double Longitude { get; set; }

    [JsonProperty("federatedSearchIndexParamsList")]
    public List<FederatedSearchIndexParam> FederatedSearchIndexParams { get; set; }

}