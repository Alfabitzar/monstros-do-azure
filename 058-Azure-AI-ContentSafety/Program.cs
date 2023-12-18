using AiTextAnalysis;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Net.Http;

string resourceKey = Environment.GetEnvironmentVariable("AI_KEY");
string endpoint = "https://maz058contentsafety.cognitiveservices.azure.com/contentsafety";

// Async call to the Content Safety API
async Task AnalyzeText(string inputText)
{
    try
    {
        var route = "/text:analyze?api-version=2023-10-01";

        var body = new { text = inputText };
        var requestBody = JsonConvert.SerializeObject(body);

        using var client = new HttpClient();
        using var request = new HttpRequestMessage();

        // Build the request.
        request.Method = HttpMethod.Post;
        request.RequestUri = new Uri(endpoint + route);
        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        request.Headers.Add("Ocp-Apim-Subscription-Key", resourceKey);

        // Send the request and get response.
        var response = await client.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        // Read response as a string.
        string result = await response.Content.ReadAsStringAsync();

        // Deserialize the response using the classes created earlier.
        var analysisResult = JsonConvert.DeserializeObject<AnalysisResult>(result);

        // Print the results.
        Console.WriteLine($"Categories found: {analysisResult.CategoriesAnalysis.Count}");
        foreach (var category in analysisResult.CategoriesAnalysis)
            Console.WriteLine($"Category: {category.Category}, Severity: {category.Severity}");

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// Simulate contact form input
var text1 = "Amei o treinamento do monstros do Azure e recomendo a todos os meus amigos, o treinamento é muito bom e o instrutor é muito bom!";
Console.WriteLine("--------------------------------");
Console.WriteLine(text1);
await AnalyzeText(text1);

var text2 = "Se voce quer fazer um treinamento lixo este é o treinamento ideal, jogue seu dinheiro fora com este treinamento de merda!";
Console.WriteLine("--------------------------------");
Console.WriteLine(text2);
await AnalyzeText(text2);

var text3 = "Depois que eu comecei este treinamento, eu entendi que minha vida não tem mais sentido...adeus mundo cruel!";
Console.WriteLine("--------------------------------");
Console.WriteLine(text3);
await AnalyzeText(text3);

var text4 = "Se eu encontrar o instrutor do monstros do Azure na rua eu vou dar um soco na cara dele, ele é muito ruim!";
Console.WriteLine("--------------------------------");
Console.WriteLine(text4);
await AnalyzeText(text4);

var text5 = "Esta procurando garotas de programa? Entre em contato com a gente, temos as melhores garotas de programa da região!";
Console.WriteLine("--------------------------------");
Console.WriteLine(text5);
await AnalyzeText(text5);