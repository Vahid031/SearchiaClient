using Searchia.Models;

namespace Searchia.Services;

public interface ISearchiaBannedExpressionClient
{
    Task<SearchiaResponse> Add(string index, BannedExpressionEnum rule, string text);
    Task<SearchiaResponse> Update(string index, string id, BannedExpressionEnum rule, string text);
    Task<SearchiaResponse> Delete(string index, string id);
    Task<SearchiaResponse<List<BannedExpression>>> Get(string index);
}

public class SearchiaBannedExpressionClient : SearchiaClient, ISearchiaBannedExpressionClient
{
    public SearchiaBannedExpressionClient(IHttpClientFactory clientFactory, ILogger<SearchiaClient> logger) : base(clientFactory, logger)
    {
    }
    public async Task<SearchiaResponse> Add(string index, BannedExpressionEnum rule, string text)
    {

        return await SendRequest($"/api/configs/qsBannedExpression/index/{index}?rule={rule}&text={text}", HttpMethod.Post);
    }

    public async Task<SearchiaResponse> Update(string index, string id, BannedExpressionEnum rule, string text)
    {
        return await SendRequest($"/api/configs/qsBannedExpression/index/{index}/id/{id}?rule={rule}&text={text}", HttpMethod.Put);
    }

    public async Task<SearchiaResponse> Delete(string index, string id)
    {
        return await SendRequest($"/api/configs/qsBannedExpression/index/{index}/id/{id}", HttpMethod.Delete);
    }

    public async Task<SearchiaResponse<List<BannedExpression>>> Get(string index)
    {
        return await SendRequest<List<BannedExpression>>($"/api/configs/qsBannedExpression/index/{index}", HttpMethod.Get);
    }
}