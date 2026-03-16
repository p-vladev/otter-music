using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.DTOs;

public record CreateAlbumDto(
    string Title,
#pragma warning disable CA1054, CA1056
    string CoverImageUrl,
#pragma warning restore CA1054, CA1056
    DateTime? ReleaseDate,
    int GenreId
    );
