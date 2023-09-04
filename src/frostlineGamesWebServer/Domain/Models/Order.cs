using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Order
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string? Description { get; set; }

    public string OrderCode { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
