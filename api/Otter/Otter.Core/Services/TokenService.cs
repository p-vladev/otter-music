using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using Otter.Core.Data;
using Otter.Core.Entities;
using Otter.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Services;

public class TokenService : ITokenService
{
    private readonly OtterDbContext context;

    public TokenService(OtterDbContext context)
    {
        this.context = context;
    }

    public string GenerateAccessToken(User user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var secretKey = Env.GetString("JWT_SECRET");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString(CultureInfo.CurrentCulture)),
            
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            
            new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User")
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(User user) 
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        var randomNumber = new byte[64];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }

        var refreshToken = Convert.ToBase64String(randomNumber);

        var userRefreshToken = new UserRefreshToken
        {
            RefreshToken = refreshToken,
            UserId = user.Id,
            ExpirationTime = DateTime.UtcNow.AddDays(7)
        };

        this.context.UserRefreshToken.Add(userRefreshToken);
        this.context.SaveChanges();

        return refreshToken;
    }
}
