using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<EndOfMatchInventory> EndOfMatchInventories { get; set; } = new List<EndOfMatchInventory>();

    public virtual ICollection<TeamAndEmployee> TeamAndEmployees { get; set; } = new List<TeamAndEmployee>();
}
