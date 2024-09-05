using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_9.Front.Models;

namespace Project_9.Front.Controllers;

[Authorize(Roles = "Admin,Member")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

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

    public async Task<IActionResult> Create()
    {
        var model = new CreateProductModel();
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"http://localhost:5135/api/categories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                model.Categories = new SelectList(data, "Id", "Definition");

                return View(model);
            }
        }

        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductModel model)
    {
        var data = TempData["Categories"]?.ToString();
        if (data != null)
        {
            var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
            model.Categories = new SelectList(categories, "Value", "Text");
        }


        if (ModelState.IsValid)
        {

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"http://localhost:5135/api/products", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError("", "fail");
            }

        }

        return View(model);
    }

    public async Task<IActionResult> Update(int id)
    {
        var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        if (token != null)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseCategory = await client.GetAsync($"http://localhost:5135/api/categories");


            var responseProduct = await client.GetAsync($"http://localhost:5135/api/products/{id}");

            if (responseProduct.IsSuccessStatusCode)
            {
                var jsonProduct = await responseProduct.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<UpdateProductModel>(jsonProduct, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });


                if (responseCategory.IsSuccessStatusCode)
                {
                    var jsonCategoryData = await responseCategory.Content.ReadAsStringAsync();

                    var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonCategoryData,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                    if (result != null)
                    {
                        result.Categories = new SelectList(data, "Id", "Definition");
                    }

                    return View(result);
                }
            }
        }

        return RedirectToAction("List");

    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductModel model)
    {
        var data = TempData["Categories"]?.ToString();
        if (data != null)
        {
            var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
            model.Categories = new SelectList(categories, "Value", "Text",model.CategoryId);
        }


        if (ModelState.IsValid)
        {

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await client.PutAsync("http://localhost:5135/api/products/", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }

                ModelState.AddModelError("", $"{response.StatusCode}");
            }

        }

        return View(model);
    }
}