# Simple.OpenAiApi

OpenAI API library

Usage:
~~~C#
// You may need to setup a credit card to your account
// After, you may also need to create a new api token
string apiKEY = "YOUR API KEY";
// Creates object
OpenAI api = new OpenAI(apiKEY);
// request a text Completion
var resp = await api.TextCompletion(new CompletionRequest()
{
    model = "text-ada-001", // cheaper for testing
    prompt = "This is a test",
    max_tokens = 25, // cheaper for testing
});
// Prints result
Console.WriteLine(resp.choices[0].text);
~~~
