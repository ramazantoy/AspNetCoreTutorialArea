﻿using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_9.Front.Models;

namespace Project_9.Front.Controllers;

[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync("http://localhost:5135/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData,
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
            var response = await client.DeleteAsync($"http://localhost:5135/api/Categories/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //return the login remove cookie
            }
        }

        return RedirectToAction("List");
    }

    public IActionResult Create()
    {
        return View(new CreateCategoryModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryModel model)
    {
        if (ModelState.IsValid)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PostAsync($"http://localhost:5135/api/Categories/", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "Fail.");
                }
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
            var response = await client.GetAsync($"http://localhost:5135/api/Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<CategoryListModel>(jsonData,
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                return View(result);
            }
        }

        return RedirectToAction("List");
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryListModel model)
    {
        if (ModelState.IsValid)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var jsonData = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.PutAsync($"http://localhost:5135/api/Categories/", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "Fail.");
                }
            }
        }

        return View(model);
    }
}