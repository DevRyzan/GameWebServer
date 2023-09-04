using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int TagPriority { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<PossibleRequestAndTag> PossibleRequestAndTags { get; set; } = new List<PossibleRequestAndTag>();

    public virtual ICollection<SupportRequestAndTag> SupportRequestAndTags { get; set; } = new List<SupportRequestAndTag>();
}
