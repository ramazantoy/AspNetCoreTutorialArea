using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Project_9.Back.Core.Application.Dto;

namespace Project_9.Back.Infrastructure.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(CheckUserResponseDto checkUserResponseDto)
    {
        var claims = new List<Claim>();

        if (!string.IsNullOrEmpty(checkUserResponseDto.Role))
        {
            claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));
        }

        claims.Add(new Claim(ClaimTypes.NameIdentifier, checkUserResponseDto.Id.ToString()));

        if (!string.IsNullOrEmpty(checkUserResponseDto.Username))
        {
            claims.Add(new Claim("UserName", checkUserResponseDto.Username));
        }

        var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        var credentials = new SigningCredentials(key: securityKey, algorithm: SecurityAlgorithms.HmacSha256);
        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer,
            audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow,
            expires: expireDate, signingCredentials: credentials);
        
        return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
    }
}