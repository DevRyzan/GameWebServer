using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class PossibleRequestAndTag
{
    public int Id { get; set; }

    public int PossibleRequestId { get; set; }

    public int TagId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual PossibleRequest PossibleRequest { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
