using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Quality
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int QualityItemSetId { get; set; }

    public int ItemId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<QualityEffect> QualityEffects { get; set; } = new List<QualityEffect>();
}
