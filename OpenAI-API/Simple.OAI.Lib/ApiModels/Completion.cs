namespace Simple.OAI.Lib.ApiModels;

public class CompletionRequest
{
    public string model { get; set; }
    public string prompt { get; set; }
    public int? max_tokens { get; set; }
    public double? temperature { get; set; }

}
public class CompletionResponse
{ 
    public string id { get; set; }
    public string _object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public Choice[] choices { get; set; }
    public Usage usage { get; set; }
}

public class Usage
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
}

public class Choice
{
    public string text { get; set; }
    public int index { get; set; }
    public int? logprobs { get; set; }
    public string finish_reason { get; set; }
}
