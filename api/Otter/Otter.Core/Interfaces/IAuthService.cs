using Otter.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Interfaces;

public interface IAuthService
{
    Task<ResponseUserDto> Register(RegisterUserDto dto);

    Task<AuthResponseDto> Login(LoginUserDto dto);

    Task<AuthResponseDto> RefreshToken(string token);
}
