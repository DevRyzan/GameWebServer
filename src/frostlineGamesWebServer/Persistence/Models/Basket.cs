using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Basket
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public double TotalPrice { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
