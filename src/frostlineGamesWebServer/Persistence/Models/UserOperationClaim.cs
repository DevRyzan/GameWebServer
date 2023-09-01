using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserOperationClaim
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int OperationClaimId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual OperationClaim OperationClaim { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
