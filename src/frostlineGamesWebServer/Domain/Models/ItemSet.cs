using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ItemSet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalItemCost { get; set; }

    public double TotalItemSellPrice { get; set; }

    public int ItemSetType { get; set; }

    public int PurchasingQuantity { get; set; }

    public int ItemSetStatId { get; set; }

    public bool Status { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
