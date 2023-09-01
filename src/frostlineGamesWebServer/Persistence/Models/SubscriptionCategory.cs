using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class SubscriptionCategory
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? BuyingDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
