using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class BardAndSkin
{
    public int Id { get; set; }

    public int BardId { get; set; }

    public int SkinId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
