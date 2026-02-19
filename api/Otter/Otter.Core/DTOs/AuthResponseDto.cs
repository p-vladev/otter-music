using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.DTOs;

public record AuthResponseDto(
    ResponseUserDto ResponseUserDto,
    string Token
);