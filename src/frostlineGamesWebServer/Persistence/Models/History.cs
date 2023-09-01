using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class History
{
    public int Id { get; set; }

    public int BardId { get; set; }

    public int ProcessName { get; set; }

    public int Time { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
