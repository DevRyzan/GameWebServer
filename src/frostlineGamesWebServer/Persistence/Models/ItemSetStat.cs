using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ItemSetStat
{
    public int Id { get; set; }

    public double? Aura { get; set; }

    public double? Armor { get; set; }

    public double? Attack { get; set; }

    public double? AttackSpeed { get; set; }

    public int ItemSetId { get; set; }

    public bool Status { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
