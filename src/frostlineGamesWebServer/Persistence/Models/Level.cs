using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Level
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int LevelQuantity { get; set; }

    public double StartedExperiencePoint { get; set; }

    public double RequiredExperiencePoint { get; set; }

    public int NextLevel { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<BardAndLevel> BardAndLevels { get; set; } = new List<BardAndLevel>();
}
