using Simple.API;
using System.Threading.Tasks;

namespace Simple.OpenAI;
/// <summary>
/// Requests data from OpenAI using it's API
/// </summary>
public class OpenAI
{
    private readonly ClientInfo client;
    /// <summary>
    /// Creates an OpenAPI API object using user's API Key
    /// </summary>
    /// <param name="key">User's API Key</param>
    public OpenAI(string key)
    {
        client = new ClientInfo("https://api.openai.com/");
        client.SetAuthorizationBearer(key);
        client.ResponseDataReceived += Client_ResponseDataReceived;
    }

    private void Client_ResponseDataReceived(object sender, ClientInfo.ResponseReceived e)
    {
        // Debug
    }

    /// <summary>
    /// Lists the currently available models
    /// </summary>
    /// <returns>Models information</returns>
    public async Task<ApiModels.Model[]> GetModelsAsync()
    {
        // GET https://api.openai.com/v1/models
        var resp = await client.GetAsync<ApiModels.ListModels>("v1/models");
        resp.EnsureSuccessStatusCode();
        return resp.Data.data;
    }
    /// <summary>
    /// Provides basic information about each model such as the owner and availability.
    /// </summary>
    /// <param name="modelId">Model id</param>
    /// <returns>Model information</returns>
    public async Task<ApiModels.Model> GetModelAsync(string modelId)
    {
        // GET https://api.openai.com/v1/models
        var resp = await client.GetAsync<ApiModels.Model>($"v1/models/{modelId}");
        resp.EnsureSuccessStatusCode();
        return resp.Data;
    }

    /// <summary>
    /// Creates a completion for the provided prompt and parameters
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <returns>Chat response</returns>
    public async Task<ApiModels.CompletionResponse> TextCompletion(ApiModels.CompletionRequest request)
    {
        var resp = await client.PostAsync<ApiModels.CompletionResponse>("v1/completions", request);
        if (!resp.IsSuccessStatusCode) { }
        resp.EnsureSuccessStatusCode();
        return resp.Data;
    }

    /// <summary>
    /// Creates a completion for the chat message
    /// </summary>
    /// <param name="request">Request parameters</param>
    /// <returns>Chat response</returns>
    public async Task<ApiModels.ChatResponse> ChatCompletionAsync(ApiModels.ChatRequest request)
    {
        var resp = await client.PostAsync<ApiModels.ChatResponse>("v1/chat/completions", request);
        if (!resp.IsSuccessStatusCode) { }
        resp.EnsureSuccessStatusCode();
        return resp.Data;
    }

}
