using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Credit
{
    public int Id { get; set; }

    public double Quantity { get; set; }

    public int BardId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Bard Bard { get; set; } = null!;
}
