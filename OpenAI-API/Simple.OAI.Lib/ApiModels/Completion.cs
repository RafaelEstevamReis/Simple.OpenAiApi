namespace Simple.OAI.Lib.ApiModels;

public class CompletionRequest
{
    public string Model { get; set; }
    public string Prompt { get; set; }
    public int? Max_Tokens { get; set; }
    public double Temperature { get; set; }

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
