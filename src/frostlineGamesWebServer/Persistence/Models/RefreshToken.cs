using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class RefreshToken
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public string CreatedByIp { get; set; } = null!;

    public DateTime? Revoked { get; set; }

    public string? RevokedByIp { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
