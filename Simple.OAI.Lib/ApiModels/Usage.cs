namespace Simple.OpenAI.ApiModels;

public class Usage
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }

    public static Usage operator +(Usage a, Usage b) => new Usage()
    {
        completion_tokens = a.completion_tokens + b.completion_tokens,
        prompt_tokens = a.prompt_tokens + b.prompt_tokens,
        total_tokens = a.total_tokens + b.total_tokens,
    };
}
