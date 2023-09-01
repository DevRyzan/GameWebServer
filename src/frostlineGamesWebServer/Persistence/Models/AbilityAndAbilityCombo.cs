using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityAndAbilityCombo
{
    public int Id { get; set; }

    public int AbilityId { get; set; }

    public int AbilityComboId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Abilitiess Ability { get; set; } = null!;

    public virtual AbilityCombo AbilityCombo { get; set; } = null!;
}
