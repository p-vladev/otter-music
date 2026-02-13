using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

[Index(nameof(ArtistName), IsUnique = true)]
[Index(nameof(UserId), IsUnique = true)]
public class Artist
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string ArtistName { get; set; } = string.Empty;

    public string? Biography { get; set; }

    public long UserId { get; set; }

    public required User User { get; set; }
}
