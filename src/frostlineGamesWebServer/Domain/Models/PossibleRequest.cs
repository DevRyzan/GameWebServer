using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class PossibleRequest
{
    public int Id { get; set; }

    public string RequestName { get; set; } = null!;

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public int SupportRequestCategoryId { get; set; }

    public int PopularityCount { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<PossibleRequestAndTag> PossibleRequestAndTags { get; set; } = new List<PossibleRequestAndTag>();

    public virtual SupportRequestCategory SupportRequestCategory { get; set; } = null!;
}
