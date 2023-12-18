using AiTextDetect;
using Newtonsoft.Json;
using System;
using System.Text;

string resourceKey = Environment.GetEnvironmentVariable("AI_KEY");
string endpoint = "https://api.cognitive.microsofttranslator.com";
string region = "brazilsouth";

// Async call to the Translator Text API
async Task TranslateText(string inputText, string[] languages)
{
    var route = "/translate?api-version=3.0&to=" + string.Join("&to=", languages);

    object[] body = new object[] { new { Text = inputText } };
    var requestBody = JsonConvert.SerializeObject(body);

    using (var client = new HttpClient())
    using (var request = new HttpRequestMessage())
    {
        // Build the request.
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(endpoint + route);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", resourceKey);
        request.Headers.Add("Ocp-Apim-Subscription-Region", region);

        // Send the request and get response.
        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
        // Read response as a string.
        string result = await response.Content.ReadAsStringAsync();

        // Deserialize the response using the classes created earlier.
        TranslationResult[] deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);

        // Iterate over the deserialized results.
        foreach (TranslationResult o in deserializedOutput)
        {
            // Print the detected input language and confidence score.
            Console.WriteLine("Detected input language: {0}\nConfidence score: {1}\n", o.DetectedLanguage.Language, o.DetectedLanguage.Score);
            // Iterate over the results and print each translation.
            foreach (Translation t in o.Translations)
            {
                Console.WriteLine("Translated to {0}: {1}", t.To, t.Text);
            }
        }
    }
}


// Async call to the Translator Text API
var langs = new string[] { "en", "es", "fr", "it", "hr", "hy" };
var inputText = "Bem vindos ao monstros do Azure! Este é um exemplo de tradução de texto usando a API de tradução do Azure. Este texto foi escrito em português e será traduzido para inglês e espanhol. Vamos lá!";
await TranslateText(inputText, langs);