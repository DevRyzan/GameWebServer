using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class EndOfMatchInventory
{
    public int Id { get; set; }

    public int BardId { get; set; }

    public int GameId { get; set; }

    public int TeamId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Slot { get; set; }

    public double Credit { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Bard Bard { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
