using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otter.Core.Entities;

public class UserRefreshToken
{
    public long Id { get; set; }

    [Required]
    public string RefreshToken { get; set; } = string.Empty;

    public DateTime ExpirationTime { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsRevoked { get; set; }

    public string? DeviceInfo { get; set; }

    public long UserId { get; set; }

    public User User { get; set; } = null!;

    public bool IsActive => !IsRevoked && ExpirationTime > DateTime.UtcNow;
}