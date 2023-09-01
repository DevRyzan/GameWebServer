using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class SupportRequestCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<PossibleRequest> PossibleRequests { get; set; } = new List<PossibleRequest>();

    public virtual ICollection<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportRequestCategories { get; set; } = new List<SupportRequestAndSupportRequestCategory>();
}
