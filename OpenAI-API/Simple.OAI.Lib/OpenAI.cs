using Simple.API;
using System.Threading.Tasks;

namespace Simple.OAI.Lib;

public class OpenAI
{
    private readonly ClientInfo client;

    public OpenAI(string key)
    {
        client = new ClientInfo("https://api.openai.com/");
        client.SetAuthorizationBearer(key);
    }

    public async Task<ApiModels.Model[]> GetModelsAsync()
    {
        // GET https://api.openai.com/v1/models
        var resp = await client.GetAsync<ApiModels.ListModels>("v1/models");
        resp.EnsureSuccessStatusCode();
        return resp.Data.data;
    }
    public async Task<ApiModels.Model> GetModelAsync(string modelId)
    {
        // GET https://api.openai.com/v1/models
        var resp = await client.GetAsync<ApiModels.Model>($"v1/models/{modelId}");
        resp.EnsureSuccessStatusCode();
        return resp.Data;
    }

    public async Task<ApiModels.CompletionResponse> TextCompletion(ApiModels.CompletionRequest request)
    {
        var resp = await client.PostAsync<ApiModels.CompletionResponse>("v1/completions", request);
        if (!resp.IsSuccessStatusCode) { }
        resp.EnsureSuccessStatusCode();
        return resp.Data;
    }

}
