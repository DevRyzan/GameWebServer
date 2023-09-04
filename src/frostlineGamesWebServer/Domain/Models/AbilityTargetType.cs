using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityTargetType
{
    public int Id { get; set; }

    public int AbilityId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsSingleTarget { get; set; }

    public bool IsAreaTarget { get; set; }

    public double Radius { get; set; }

    public string IconUrl { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Abilitiess Ability { get; set; } = null!;
}
