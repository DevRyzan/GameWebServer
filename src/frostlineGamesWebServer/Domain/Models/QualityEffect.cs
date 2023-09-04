using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class QualityEffect
{
    public int Id { get; set; }

    public int TriggerId { get; set; }

    public int ConditionId { get; set; }

    public int QualityId { get; set; }

    public int EffectType { get; set; }

    public int ModifierOperation { get; set; }

    public int DurationPolicy { get; set; }

    public int EffectStatType { get; set; }

    public string EffectName { get; set; } = null!;

    public string EffectDescription { get; set; } = null!;

    public string EffectTarget { get; set; } = null!;

    public double Effect1 { get; set; }

    public double? Duration { get; set; }

    public double CoolDown { get; set; }

    public string AttributesName { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Condition Condition { get; set; } = null!;

    public virtual Quality Quality { get; set; } = null!;

    public virtual Trigger Trigger { get; set; } = null!;
}
