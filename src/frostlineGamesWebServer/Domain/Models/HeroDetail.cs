using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class HeroDetail
{
    public int Id { get; set; }

    public int HeroId { get; set; }

    public string Description { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Story { get; set; } = null!;

    public string IconUrl { get; set; } = null!;

    public double GamPrice { get; set; }

    public double CreditPrice { get; set; }

    public DateTime PurchasedDate { get; set; }

    public DateTime ReturnedDate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Hero Hero { get; set; } = null!;
}
