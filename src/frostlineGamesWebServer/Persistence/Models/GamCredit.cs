using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class GamCredit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Quantity { get; set; }

    public int BardId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Bard Bard { get; set; } = null!;
}
