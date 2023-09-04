using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class EloRank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double EloRankPoint { get; set; }

    public double RequiredEloRankPoint { get; set; }

    public double EarnedPoint { get; set; }

    public double LostPoint { get; set; }

    public double NextEloRank { get; set; }

    public int PlayerRanks { get; set; }

    public int PlayerRankRows { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<BardAndEloRank> BardAndEloRanks { get; set; } = new List<BardAndEloRank>();
}
