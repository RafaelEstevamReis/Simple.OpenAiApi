using Simple.OAI.Lib;
using Simple.OAI.Lib.ApiModels;
using System;
using System.IO;

const string KEY_FILE = "key.txt";

Console.WriteLine("Hello, World!");

if (!File.Exists(KEY_FILE))
{
    Console.WriteLine("Enter OpenAI key:");
    string key = Console.ReadLine() ?? "";
    File.WriteAllText(KEY_FILE, key);
}
// You may need to setup a credit card to your account
// After, you may also need to create a new api token
OpenAI api = new OpenAI(File.ReadAllLines(KEY_FILE)[0]);


//Console.WriteLine("List All");
//var models = await api.GetModelsAsync();
//foreach (var model in models)
//{
//    Console.WriteLine(model.id);
//}

//// Get Whisper
//Console.WriteLine(await api.GetModelAsync("text-ada-001"));



Usage usage = new Usage();
Console.WriteLine("Send an empty prompt to quit");
while (true)
{
    Console.Write("> ");
    string prompt = Console.ReadLine() ?? "";
    if (string.IsNullOrEmpty(prompt)) break;

    var resp = await api.TextCompletion(new Simple.OAI.Lib.ApiModels.CompletionRequest()
    {
        //model = "text-ada-001", // cheaper for testing
        model = "text-babbage-001",
        prompt = prompt,
        max_tokens = 25, // cheaper for testing
    });

    for (int i = 0; i < resp.choices.Length; i++)
    {
        Console.Write($"[{i + 1}]> " + resp.choices[i].text);
        Console.WriteLine("[" + resp.choices[i].finish_reason + "]");
        Console.WriteLine();
    }
    Console.WriteLine();
    usage += resp.usage;
}
Console.WriteLine("----");
Console.WriteLine("Total Usage:");
Console.WriteLine($"prompt_tokens: {usage.prompt_tokens}");
Console.WriteLine($"completion_tokens: {usage.completion_tokens}");
Console.WriteLine($"total_tokens: {usage.total_tokens}");

Console.WriteLine("END");