using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_9.Front.Models;

namespace Project_9.Front.Controllers;

[Authorize(Roles = "Admin,Member")]
public class ProductController : Controller
{
    private IHttpClientFactory _httpClientFactory;

    // GET
    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> List()
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("http://localhost:5135/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductListModel>>(jsonData,
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                return View(result);
            }
        }

        return View();
    }

    public async Task<IActionResult> Remove(int id)
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"http://localhost:5135/api/Products/{id}");
        }

        return RedirectToAction("List");
    }
}