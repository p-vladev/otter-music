using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

public class Song
{
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Duration { get; set; }

    [Required]
    public long AlbumId {  get; set; }

    #pragma warning disable CA1056
    public string? CoverImageUrl { get; set; }
    #pragma warning restore CA1056

    [Required]
    #pragma warning disable CA1056
    public string FileUrl { get; set; } = string.Empty;
    #pragma warning restore CA1056

    public DateTime? ReleaseDate { get; set; } = DateTime.MinValue;

    [Required]
    public int GenreId { get; set; }

    public required Album Album { get; set; }

    public required Genre Genre { get; set; }
}
