using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class SupportRequestAndSupportRequestCategory
{
    public int Id { get; set; }

    public int SupportRequestCategoryId { get; set; }

    public int SupportRequestId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SupportRequest SupportRequest { get; set; } = null!;

    public virtual SupportRequestCategory SupportRequestCategory { get; set; } = null!;
}
