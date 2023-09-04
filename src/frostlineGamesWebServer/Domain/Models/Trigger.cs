using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Trigger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual QualityEffect? QualityEffect { get; set; }
}
