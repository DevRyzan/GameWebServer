using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityDamageType
{
    public int Id { get; set; }

    public int AbilityId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Abilitiess Ability { get; set; } = null!;
}
