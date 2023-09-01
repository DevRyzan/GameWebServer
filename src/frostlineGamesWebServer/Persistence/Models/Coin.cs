using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Coin
{
    public int Id { get; set; }

    public int Gold { get; set; }

    public int BardId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
