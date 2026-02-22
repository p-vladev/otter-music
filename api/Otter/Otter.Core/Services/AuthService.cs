using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otter.Core.Data;
using Otter.Core.DTOs;
using Otter.Core.Interfaces;
using Otter.Core.Mappers;

namespace Otter.Core.Services;

public class AuthService : IAuthService
{
    private readonly OtterDbContext context;
    private readonly ITokenService tokenService;

    public AuthService (OtterDbContext context, ITokenService tokenService)
    {
        this.context = context;
        this.tokenService = tokenService;
    }

    public async Task<AuthResponseDto> Register(RegisterUserDto dto)
    {
        if (await context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            throw new ArgumentException("Email is already in use!");
        }

        var user = dto.ToEntity();

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        this.context.Users.Add(user);
        await context.SaveChangesAsync();

        string token = tokenService.GenerateAccessToken(user);

        return new AuthResponseDto(
            user.ToResponseUserDto(), 
            token, 
            tokenService.GenerateRefreshToken(user)
        );
    }

    public async Task<AuthResponseDto> Login(LoginUserDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
        {
            throw new ArgumentException("Email is incorrect!");
        }

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            throw new ArgumentException("Password is incorrect!");
        }

        return new AuthResponseDto(
            user.ToResponseUserDto(), 
            tokenService.GenerateAccessToken(user), 
            tokenService.GenerateRefreshToken(user)
        );
    }

    public async Task<AuthResponseDto> RefreshToken(string token)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(token, nameof(token));

        var refreshToken = await context.UserRefreshToken
            .Include(t => t.User)
            .ThenInclude(u => u.Role)
            .FirstOrDefaultAsync(t => t.RefreshToken == token);

        if (refreshToken == null) {
            throw new ArgumentException("Token is incorrect or not found.");
        }

        if (refreshToken.ExpirationTime < DateTime.UtcNow) { 
            this.context.UserRefreshToken.Remove(refreshToken);
            await this.context.SaveChangesAsync();

            throw new UnauthorizedAccessException("Refresh token expired. Please login again.");
        }

        this.context.UserRefreshToken.Remove(refreshToken);
        await this.context.SaveChangesAsync();

        return new AuthResponseDto(
            refreshToken.User.ToResponseUserDto(),
            tokenService.GenerateAccessToken(refreshToken.User),
            tokenService.GenerateRefreshToken(refreshToken.User)
        );
    }
}
