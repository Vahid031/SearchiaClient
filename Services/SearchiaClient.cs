using System.Text;
using Newtonsoft.Json;
using Searchia.Models;

namespace Searchia.Services;

public abstract class SearchiaClient
{
    public const string ClientName = "SearchiaClient";
    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<SearchiaClient> _logger;

    protected SearchiaClient(IHttpClientFactory clientFactory, ILogger<SearchiaClient> logger)
    {
        _clientFactory = clientFactory;
        _logger = logger;
    }

    protected async Task<SearchiaResponse<T>> SendRequest<T>(string url, HttpMethod httpMethod, object model)
    {
        var content = await GetResponseContent(url, httpMethod, model);

        return JsonConvert.DeserializeObject<SearchiaResponse<T>>(content);
    }

    protected async Task<SearchiaResponse> SendRequest(string url, HttpMethod httpMethod)
    {
        var content = await GetResponseContent(url, httpMethod, null);

        return JsonConvert.DeserializeObject<SearchiaResponse>(content);
    }

    protected async Task<SearchiaResponse<T>> SendRequest<T>(string url, HttpMethod httpMethod)
    {
        var content = await GetResponseContent(url, httpMethod, null);

        return JsonConvert.DeserializeObject<SearchiaResponse<T>>(content);
    }

    protected async Task<SearchiaResponse> SendRequest(string url, HttpMethod httpMethod, object model)
    {
        var content = await GetResponseContent(url, httpMethod, model);

        return JsonConvert.DeserializeObject<SearchiaResponse>(content);
    }

    private async Task<string> GetResponseContent(string url, HttpMethod httpMethod, object model)
    {
        using var client = _clientFactory.CreateClient(ClientName);

        var request = new HttpRequestMessage(httpMethod, url);
        
        if (model != null)
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        }

        var response = await client.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode is false)
        {
            _logger.LogError($"SendSearchiaRequestAsync failed with response : {response.Content}");
        }

        return content;
    }
}