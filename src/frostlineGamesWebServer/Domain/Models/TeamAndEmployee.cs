using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class TeamAndEmployee
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int EmployeeId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
