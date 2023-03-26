using System;

namespace Simple.OpenAI.ApiModels;

public class ChatRequest
{
    public string model { get; set; }
    public ChatMessage[] messages { get; set; }
    public int? max_tokens { get; set; }
    public double? temperature { get; set; }
}
public class ChatMessage
{
    public const string ROLE_USER = "user";
    public const string ROLE_SYSTEM = "system";
    public const string ROLE_ASSISTANT = "assistant";

    public string role { get; set; }
    public string content { get; set; }
}


public class ChatResponse
{
    public string id { get; set; }
    public string @object { get; set; }
    public long created { get; set; }
    public DateTime createdAt => DateTime.UnixEpoch.AddSeconds(created);
    public ChatChoices[] choices { get; set; }
    public Usage usage { get; set; }
}
public class ChatChoices
{
    public int index { get; set; }
    public ChatMessage message { get; set; }
    public string finish_reason { get; set; }
}

