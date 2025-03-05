using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "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";
        Console.WriteLine("Lütfen sorununuzu yazın:(Örnek Denizlide hava kaç derece ?)");
        
        var prompt = Console.ReadLine();
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new {role="system",content="Ypu are a helpful asistant"},
                new {role="user", content=prompt}
            },
            max_tokens = 100
        };
        var json = JsonSerializer.Serialize(requestBody); 
        var content = new StringContent(json,Encoding.UTF8,"application/json");

        try
        {
            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<JsonElement>(responseString);
                var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                Console.WriteLine("OpenAI'nin cevabı: ");
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine($"Bir hata oluştu:{response.StatusCode}");
                Console.WriteLine(responseString); 
            }
        }
        catch (Exception e)
        {

            Console.WriteLine($"Bir hata oluştu:{e.Message}");
        }
    }

}

//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