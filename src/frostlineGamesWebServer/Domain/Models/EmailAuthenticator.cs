using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class EmailAuthenticator
{
    public int Id { get; set; }

    public string? ActivationKey { get; set; }

    public bool IsVerified { get; set; }

    public Guid UserId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
