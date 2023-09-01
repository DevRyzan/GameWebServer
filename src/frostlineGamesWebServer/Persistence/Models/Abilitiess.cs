using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Abilitiess
{
    public int Id { get; set; }

    public int HeroId { get; set; }

    public int AbilityLevelId { get; set; }

    public int AbilityComboId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string IconUrl { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<AbilityAndAbilityCategory> AbilityAndAbilityCategories { get; set; } = new List<AbilityAndAbilityCategory>();

    public virtual ICollection<AbilityAndAbilityCombo> AbilityAndAbilityCombos { get; set; } = new List<AbilityAndAbilityCombo>();

    public virtual ICollection<AbilityAndAbilityLevel> AbilityAndAbilityLevels { get; set; } = new List<AbilityAndAbilityLevel>();

    public virtual AbilityDamageType? AbilityDamageType { get; set; }

    public virtual AbilityDetail? AbilityDetail { get; set; }

    public virtual ICollection<AbilityEffectStat> AbilityEffectStats { get; set; } = new List<AbilityEffectStat>();

    public virtual ICollection<AbilityImageFile> AbilityImageFiles { get; set; } = new List<AbilityImageFile>();

    public virtual AbilityTargetType? AbilityTargetType { get; set; }

    public virtual AbilityType? AbilityType { get; set; }

    public virtual EffectType? EffectType { get; set; }

    public virtual Hero Hero { get; set; } = null!;
}
