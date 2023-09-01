using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class EndOfMatchInventoryAndItem
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int EndOfMatchInventoryId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
