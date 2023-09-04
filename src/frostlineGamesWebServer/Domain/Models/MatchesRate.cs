using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class MatchesRate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TotalRate { get; set; }

    public int WinRate { get; set; }

    public int LostRate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<BardAndMatchesRate> BardAndMatchesRates { get; set; } = new List<BardAndMatchesRate>();
}
