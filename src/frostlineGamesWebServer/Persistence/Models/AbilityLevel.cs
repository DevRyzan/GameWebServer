using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityLevel
{
    public int Id { get; set; }

    public int LevelNumber { get; set; }

    public string Description { get; set; } = null!;

    public double Duration { get; set; }

    public double Range { get; set; }

    public double EnergyCost { get; set; }

    public string IconUrl { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<AbilityAndAbilityLevel> AbilityAndAbilityLevels { get; set; } = new List<AbilityAndAbilityLevel>();
}
