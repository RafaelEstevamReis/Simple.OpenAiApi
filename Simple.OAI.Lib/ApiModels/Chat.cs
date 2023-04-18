namespace Simple.OpenAI.ApiModels;

using Newtonsoft.Json;
using System;

public class ChatRequest
{
    /// <summary>
    /// ID of the model to use. See the model endpoint compatibility table for details on which models work with the Chat API.
    /// https://platform.openai.com/docs/models/model-endpoint-compatibility
    /// </summary>
    public string model { get; set; }
    /// <summary>
    /// The messages to generate chat completions for, in the chat format.
    /// </summary>
    public ChatMessage[] messages { get; set; }
    /// <summary>
    /// The maximum number of tokens to generate in the chat completion.
    /// The total length of input tokens and generated tokens is limited by the model's context length.
    /// </summary>
    public int? max_tokens { get; set; }
    /// <summary>
    /// What sampling temperature to use, between 0 and 2. 
    /// Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
    /// </summary>
    public double? temperature { get; set; }
    /// <summary>
    /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string user { get; set; }
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

    public string text => message.content;
}

