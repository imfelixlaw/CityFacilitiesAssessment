using Newtonsoft.Json;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Services;

public class ForwarderService : IForwarderService
{
    private readonly IConfiguration _configuration;
    public ForwarderService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<Product>> GetProductFromVendor()
    {
        string apikey = _configuration.GetValue<string>("apikey");
        string apiendpoint = _configuration.GetValue<string>("apiendpoint");
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, apiendpoint);
        request.Headers.Add("API-KEY", apikey);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string json = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(json))
        {
            return new List<Product>();
        }

        return JsonConvert.DeserializeObject<List<Product>>(json);
    }
}
