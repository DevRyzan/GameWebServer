using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class BardAndEloRank
{
    public int Id { get; set; }

    public int BardId { get; set; }

    public int EloRankId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Bard Bard { get; set; } = null!;

    public virtual EloRank EloRank { get; set; } = null!;
}
