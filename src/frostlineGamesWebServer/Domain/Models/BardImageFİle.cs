using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class BardImageFİle
{
    public int Id { get; set; }

    public bool Showcase { get; set; }

    public int BardId { get; set; }

    public virtual Bard Bard { get; set; } = null!;

    public virtual File IdNavigation { get; set; } = null!;
}
