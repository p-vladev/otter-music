using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Otter.Core.Entities;

[Index(nameof(GenreName), IsUnique = true)]
public class Genre
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string GenreName { get; set; } = string.Empty;
}
