namespace Project_9.Front.Models;

public class JwtTokenResponseModel
{
    public string? Token { get; set; }
    public DateTime ExpireDate { get; set; }
}