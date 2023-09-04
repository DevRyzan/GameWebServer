using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double BuyCost { get; set; }

    public double SellPrice { get; set; }

    public string IconUrl { get; set; } = null!;

    public int QualityType { get; set; }

    public int? ItemCategory { get; set; }

    public int ItemType { get; set; }

    public int ItemHeroType { get; set; }

    public int OperatorType { get; set; }

    public int HowManyPassive { get; set; }

    public int HowManyStat { get; set; }

    public bool? IsStackable { get; set; }

    public bool? IsConsumable { get; set; }

    public bool? IsGlpyh { get; set; }

    public bool IsHaveEffect { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Quality? Quality { get; set; }
}
