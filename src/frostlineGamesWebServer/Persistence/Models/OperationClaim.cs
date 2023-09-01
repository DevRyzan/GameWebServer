using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class OperationClaim
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();
}
