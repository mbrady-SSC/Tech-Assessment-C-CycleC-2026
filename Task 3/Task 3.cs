using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        await ApiFetch();
    }

    static async Task ApiFetch()
    {
        try
        {
            // Read the base URL from the .env file
            string? baseUrl = GetEnvironmentVariableFromDotEnv("API_BASE_URL");

            // Error handling: stop if the base URL was not found
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                Console.WriteLine("Error: API_BASE_URL is missing from the .env file.");
                return;
            }

            // Build the full URL for the posts endpoint
            string url = baseUrl.TrimEnd('/') + "/posts";

            using HttpClient client = new HttpClient();

            // Make the GET request
            HttpResponseMessage response = await client.GetAsync(url);

            // Error handling: check that the request worked
            if (!response.IsSuccessStatusCode)
                throw new Exception($"HTTP error! Status: {response.StatusCode}");

            // Parse the JSON response
            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);

            // Error handling: make sure at least one post came back
            if (doc.RootElement.GetArrayLength() == 0)
            {
                Console.WriteLine("No posts were returned.");
                return;
            }

            // Extract and print the "title" field from the first post
            Console.WriteLine("First Post Title: " + doc.RootElement[0].GetProperty("title").GetString());
        }
        catch (Exception ex)
        {
            // Error handling: catch network problems or bad responses
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Read a value straight from the .env file
    static string? GetEnvironmentVariableFromDotEnv(string variableName)
    {
        try
        {
            // Look for the .env file inside the Task 3 folder
            string envFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Task 3", ".env");

            if (File.Exists(envFilePath))
            {
                string[] lines = File.ReadAllLines(envFilePath);

                foreach (string line in lines)
                {
                    if (line.StartsWith(variableName + "="))
                    {
                        return line.Substring(variableName.Length + 1).Trim();
                    }
                }
            }
        }
        catch
        {
            // If there's any error reading the file, return null
        }

        return null;
    }
}