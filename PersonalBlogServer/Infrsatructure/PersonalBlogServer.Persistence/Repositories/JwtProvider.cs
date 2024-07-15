using Microsoft.IdentityModel.Tokens;
using PersonalBlogServer.Application.Repositories;
using PersonalBlogServer.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonalBlogServer.Persistence.Repositories;

public class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
        };

        DateTime expires = DateTime.Now.AddDays(1);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(string.Join('-', Guid.NewGuid(), Guid.NewGuid())));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: "Ahmet Hakan Eroğlu",
            audience: "personalblog.aheroglu.dev",
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;
    }
}
