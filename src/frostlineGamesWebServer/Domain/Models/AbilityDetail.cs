using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityDetail
{
    public int Id { get; set; }

    public int AbilityId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double CoolDown { get; set; }

    public double Percent { get; set; }

    public double Range { get; set; }

    public double Radius { get; set; }

    public double EnergyCost { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Abilitiess Ability { get; set; } = null!;
}
