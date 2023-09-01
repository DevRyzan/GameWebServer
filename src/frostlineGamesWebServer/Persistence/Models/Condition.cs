using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Condition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int OperatorType { get; set; }

    public double Value { get; set; }

    public string AttributesName { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual QualityEffect? QualityEffect { get; set; }
}
