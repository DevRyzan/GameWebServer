using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class GetInTouch
{
    public int Id { get; set; }

    public string ConcactName { get; set; } = null!;

    public string ContactEmail { get; set; } = null!;

    public string ContactSubject { get; set; } = null!;

    public string ContactMessage { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
