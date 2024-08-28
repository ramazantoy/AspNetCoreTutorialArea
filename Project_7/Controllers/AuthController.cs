using Microsoft.AspNetCore.Mvc;

namespace Project_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Created("", new JwtTokenGenerator().GenerateToken());
        }
    }
}