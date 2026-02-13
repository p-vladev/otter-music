using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

[Index(nameof(TypeName), IsUnique = true)]
public class PlaylistType
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string TypeName { get; set; } = string.Empty;
}
