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

    public AuthService (OtterDbContext context)
    {
        this.context = context;
    }

    public async Task<ResponseUserDto> Register(RegisterUserDto dto)
    {
        if (await context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            throw new ArgumentException("Email is already in use!");
        }

        var user = dto.ToEntity();

        user.PasswordHash = "hash_" + dto.Password;

        this.context.Users.Add(user);
        await context.SaveChangesAsync();

        return user.ToResponseUserDto();
    }

    public Task<AuthResponseDto> Login(LoginUserDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseDto> RefreshToken(string token)
    {
        throw new NotImplementedException();
    }
}
