using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class SupportRequestComment
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public bool IsEdited { get; set; }

    public int SupportRequestId { get; set; }

    public Guid UserId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual SupportRequest SupportRequest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
