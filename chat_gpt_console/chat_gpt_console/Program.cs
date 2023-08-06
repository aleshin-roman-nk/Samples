using chat_gpt_console;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

var apiKey = "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";
string apiUrl = "https://api.openai.com/v1/completions";

// Create the JSON payload
//string payload = $"{{ \"prompt\": \"{prompt}\", \"max_tokens\": {maxTokens} }}";

//var payload = new
//{
//    model = "text-davinci-003",
//    prompt = "How to express this expression in English:\n\nСказать что ты не интересен это ничего не сказать.",
//    temperature = 0,
//    max_tokens = 60,
//    top_p = 1.0,
//    frequency_penalty = 0.0,
//    presence_penalty = 0.0
//};

string input = "";

while (true)
{
    Console.Write("(stop for exit) > ");
    input = Console.ReadLine();

    if (input.ToLower().Equals("stop".ToLower())) break;

    var payload = new
    {
        model = "text-davinci-003",
        //prompt = "How to express this expression in English: Сказать что ты не интересен это ничего не сказать",
        prompt = $"Is this grammatically correct (answer only yes or no)'{ input}'",
        temperature = 1,
        max_tokens = 60,
        top_p = 1.0,
        frequency_penalty = 0.0,
        presence_penalty = 0.0
    };

    var payload_str = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

    var content = new StringContent(payload_str, Encoding.UTF8, "application/json");

    // Set the authorization header with your API key
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        // Send the POST request to the API
        var response = await client.PostAsync(apiUrl, content);

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content
            string responseContent = await response.Content.ReadAsStringAsync();
            TextCompletion res = Newtonsoft.Json.JsonConvert.DeserializeObject<TextCompletion>(responseContent);
            Console.WriteLine($"[{res.Choices[0].Text}]");
        }
        else
        {
            Console.WriteLine($"Error: {(int)response.StatusCode} - {response.ReasonPhrase}");
        }
    }
}


//Console.ReadLine();