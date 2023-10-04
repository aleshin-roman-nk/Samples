// See https://aka.ms/new-console-template for more information
using System.Text;

var apiKey = "t.bgNV6s3lRpGUOshQce4gWQi_eBRHYhb45DvhD7Nxlb9kzUjKYwSN4BwqCbFoyQUlbuilhyoRqXScGCUKXZumiA";
//string apiUrl = "https://invest-public-api.tinkoff.ru/rest/tinkoff.public.invest.api.contract.v1.InstrumentsService";


//var payload = new
//{
//	temperature = 1,
//	max_tokens = 60,
//	top_p = 1.0,
//	frequency_penalty = 0.0,
//	presence_penalty = 0.0
//};

//var payload_str = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

//var content = new StringContent(payload_str, Encoding.UTF8, "application/json");

//// Set the authorization header with your API key
//using (var client = new HttpClient())
//{
//	client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

//	// Send the POST request to the API
//	var response = await client.PostAsync(apiUrl, content);

//	// Check if the request was successful
//	if (response.IsSuccessStatusCode)
//	{
//		// Read the response content
//		string responseContent = await response.Content.ReadAsStringAsync();
//		TextCompletion res = Newtonsoft.Json.JsonConvert.DeserializeObject<TextCompletion>(responseContent);
//		Console.WriteLine($"[{res.Choices[0].Text}]");
//	}
//	else
//	{
//		Console.WriteLine($"Error: {(int)response.StatusCode} - {response.ReasonPhrase}");
//	}
//}