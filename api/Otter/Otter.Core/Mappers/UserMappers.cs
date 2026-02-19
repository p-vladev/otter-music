using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter.Core.Entities;
using Otter.Core.DTOs;

namespace Otter.Core.Mappers;

public static class UserMappers
{
    public static ResponseUserDto ToResponseUserDto(this User user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        return new ResponseUserDto
        (
            user.Id,
            user.FirstName,
            user.LastName,
            user.Username,
            user.Email,
            user.DateOfBirth,
            user.Role?.RoleName ?? "User"
        );
    }

    public static User ToEntity(this RegisterUserDto dto, int roleId = 1)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = dto.Password,
            DateOfBirth = dto.DateOfBirth,
            RoleId = roleId,
            Role = null!
        };
    }
}
