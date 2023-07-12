using Searchia.Controllers;
using Searchia.Models;

namespace Searchia.Services;

public interface ISearchiaCommandClient
{
    Task<SearchiaResponse<DocumentInfo>> CreateDoc<TEntity>(string index, TEntity model) where TEntity : BaseCommandDoc;
    Task<SearchiaResponse<DocumentsInfo>> CreateDocs<TEntity>(string index, List<TEntity> model) where TEntity : BaseCommandDoc;
    Task<SearchiaResponse<DocumentInfo>> UpdateDoc<TEntity>(string index, TEntity model) where TEntity : BaseCommandDoc;
    Task<SearchiaResponse<DocumentsInfo>> UpdateDocs<TEntity>(string index, List<TEntity> model) where TEntity : BaseCommandDoc;
    Task<SearchiaResponse<DocumentInfo>> Increment(string index, string id, string field, uint value);
    Task<SearchiaResponse<DocumentInfo>> Decrement(string index, string id, string field, uint value);
    Task<SearchiaResponse> DeleteDoc(string index, string id);
    Task<SearchiaResponse<DocumentsInfo>> DeleteDocs(string index, List<string> ids);
    Task<SearchiaResponse> Click(string index, string id, string queryId, uint position, string userToken);
    Task<SearchiaResponse> Cart(string index, string id);
    Task<SearchiaResponse> Cart(string index, string id, string queryId, string userToken);
}

public class SearchiaCommandClient : SearchiaClient, ISearchiaCommandClient
{
    public SearchiaCommandClient(IHttpClientFactory clientFactory, ILogger<SearchiaClient> logger) 
        : base(clientFactory, logger)
    {
    }

    public async Task<SearchiaResponse<DocumentInfo>> CreateDoc<TEntity>(string index, TEntity model) 
        where TEntity : BaseCommandDoc
    {
        return await SendRequest<DocumentInfo>($"/api/index/{index}/storeDoc", HttpMethod.Post, model);
    }

    public async Task<SearchiaResponse<DocumentsInfo>> CreateDocs<TEntity>(string index, List<TEntity> model) 
        where TEntity : BaseCommandDoc
    {
        return await SendRequest<DocumentsInfo>($"/api/index/{index}/storeDocs", HttpMethod.Post, model);
    }

    public async Task<SearchiaResponse<DocumentInfo>> UpdateDoc<TEntity>(string index, TEntity model) 
        where TEntity : BaseCommandDoc
    {
        return await SendRequest<DocumentInfo>($"/api/index/{index}/doc/{model.Id}", HttpMethod.Put, model);
    }

    public async Task<SearchiaResponse<DocumentsInfo>> UpdateDocs<TEntity>(string index, List<TEntity> model) 
        where TEntity : BaseCommandDoc
    {
        return await SendRequest<DocumentsInfo>($"/api/index/{index}/updateDocs/", HttpMethod.Put, model);
    }

    public async Task<SearchiaResponse<DocumentInfo>> Increment(string index, string id, string field, uint value)
    {
        return await SendRequest<DocumentInfo>($"/api/index/{index}/doc/{id}/field/{field}/incrementValue/{value}", HttpMethod.Put);
    }

    public async Task<SearchiaResponse<DocumentInfo>> Decrement(string index, string id, string field, uint value)
    {
        return await SendRequest<DocumentInfo>($"/api/index/{index}/doc/{id}/field/{field}/decrementValue/{value}", HttpMethod.Put);
    }

    public async Task<SearchiaResponse> DeleteDoc(string index, string id)
    {
        return await SendRequest($"/api/index/{index}/doc/{id}", HttpMethod.Delete);
    }

    public async Task<SearchiaResponse<DocumentsInfo>> DeleteDocs(string index, List<string> ids)
    {
        return await SendRequest<DocumentsInfo>($"/api/index/{index}/docs", HttpMethod.Delete, ids);
    }

    public async Task<SearchiaResponse> Click(string index, string id, string queryId, uint position, string userToken)
    {
        return await SendRequest($"/api/clickWithQueryId/index/{index}/doc/{id}?queryId={queryId}&position={position}&userToken={userToken}", HttpMethod.Put);
    }

    public async Task<SearchiaResponse> Cart(string index, string id)
    {
        return await SendRequest($"/api/cart/index/{index}/doc/{id}", HttpMethod.Put);
    }

    public async Task<SearchiaResponse> Cart(string index, string id, string queryId, string userToken)
    {
        return await SendRequest($"/api/addToCartWithQueryId/index/{index}/doc/{id}?queryId={queryId}&userToken={userToken}", HttpMethod.Put);
    }
}