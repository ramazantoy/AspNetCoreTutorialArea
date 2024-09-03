using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Project_9.Front.Models;

namespace Project_9.Front.Controllers;

public class AccountController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public AccountController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public IActionResult Login()
    {
        return View(new UserLoginModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        if (ModelState.IsValid)
        {
            var client = _clientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5135/api/auth/login", content);


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var responseModel = JsonSerializer.Deserialize<JwtTokenResponseModel>(jsonData,new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (responseModel != null)
                {
                    var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtSecurityTokenHandler.ReadJwtToken(responseModel.Token);

                    var claims = token.Claims.ToList();

                    if (responseModel.Token!= null)
                    {
                        claims.Add(new Claim("accessToken",responseModel.Token));
                    }
                        
                
                    
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties()
                    {
                        ExpiresUtc = responseModel.ExpireDate,
                        IsPersistent = true,
                    };
                  await  HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),authProps);
                  return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Username or password is wrong.");
            }

            return View();
        }

        return View(model);
    }
}