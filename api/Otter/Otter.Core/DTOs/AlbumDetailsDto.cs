using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.DTOs;

public record AlbumDetailsDto(
    long Id,
    string Title,
    string ArtistName,
#pragma warning disable CA1054, CA1056 // URI-like parameters should not be strings
    string CoverImageUrl,
#pragma warning restore CA1054, CA1056 // URI-like parameters should not be strings
    DateTime ReleaseDate,
    IEnumerable<SongDto> Songs
    );
