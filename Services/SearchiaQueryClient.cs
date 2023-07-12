using Searchia.Controllers;
using Searchia.Models;
using System.Web;

namespace Searchia.Services;

public interface ISearchiaQueryClient
{
    Task<SearchiaResponse<SearchResult<TEntity>>> Search<TEntity>(string index, string query) where TEntity : BaseQueryDoc;
    Task<SearchiaResponse<List<RequestResult<TEntity>>>> Search<TEntity>(List<SearchRequest> model) where TEntity : BaseQueryDoc;
    Task<SearchiaResponse<SearchResult<TEntity>>> Search<TEntity>(FederatedSearchRequest model) where TEntity : BaseQueryDoc;
    Task<SearchiaResponse<TEntity>> SearchByDocId<TEntity>(string index, string docId) where TEntity : BaseQueryDoc;
    Task<SearchiaResponse<SuggestResult>> Suggest(SuggestRequest model);
    Task<SearchiaResponse<UserHistoryResult>> UserHistory(string index, string userToken, int size);
    Task<SearchiaResponse<ScrollResult>> Scroll(ScrollRequest model);
}

public class SearchiaQueryClient : SearchiaClient, ISearchiaQueryClient
{
    public SearchiaQueryClient(IHttpClientFactory clientFactory, ILogger<SearchiaClient> logger) 
        : base(clientFactory, logger)
    {

    }

    public async Task<SearchiaResponse<SearchResult<TEntity>>> Search<TEntity>(string index, string query) 
        where TEntity : BaseQueryDoc
    {
        return await SendRequest<SearchResult<TEntity>>($"/api/index/{index}?query={query}", HttpMethod.Get);
    }

    public async Task<SearchiaResponse<List<RequestResult<TEntity>>>> Search<TEntity>(List<SearchRequest> model) 
        where TEntity : BaseQueryDoc
    {
        return await SendRequest<List<RequestResult<TEntity>>>($"/api/bulkSearch", HttpMethod.Post, model);
    }

    public async Task<SearchiaResponse<SearchResult<TEntity>>> Search<TEntity>(FederatedSearchRequest model) 
        where TEntity : BaseQueryDoc
    {
        return await SendRequest<SearchResult<TEntity>>($"/api/federatedSearch", HttpMethod.Post, model);
    }

    public async Task<SearchiaResponse<TEntity>> SearchByDocId<TEntity>(string index, string docId) 
        where TEntity : BaseQueryDoc
    {
        return await SendRequest<TEntity>($"/api/index/{index}/doc/{docId}", HttpMethod.Get);
    }

    public async Task<SearchiaResponse<SuggestResult>> Suggest(SuggestRequest model)
    {
        var queryString = HttpUtility.ParseQueryString("?");
        queryString.Add("query", model.Query);
        queryString.Add("includeDocCount", model.IncludeDocCount.ToString());
        queryString.Add("inContent", model.InContent.ToString());
        queryString.Add("filter", model.Filter);
        queryString.Add("objectCategoryIdFieldName", model.ObjectCategoryIdFieldName);
        queryString.Add("spellCheckEnabled", model.SpellCheckEnabled.ToString());
        queryString.Add("analyticsTag", model.AnalyticsTag);



        return await SendRequest<SuggestResult>($"/api/qs/index/{model.IndexName}?{queryString}", HttpMethod.Get);
    }

    public async Task<SearchiaResponse<UserHistoryResult>> UserHistory(string index, string userToken, int size)
    {
        return await SendRequest<UserHistoryResult>($"/api/userQueryProfile/index/{index}/userToken/{userToken}?size={size}", HttpMethod.Get);
    }

    public async Task<SearchiaResponse<ScrollResult>> Scroll(ScrollRequest model)
    {
        var queryString = HttpUtility.ParseQueryString("?");
        queryString.Add("query", model.Query);
        queryString.Add("fieldName", model.FieldName);
        queryString.Add("filters", model.Filters);
        queryString.Add("chunkNo", model.ChunkNo.ToString());


        return await SendRequest<ScrollResult>($"/api/scroll/{model.IndexName}?{queryString}", HttpMethod.Get);
    }
}