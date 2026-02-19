using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.DTOs;

public record LoginUserDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);