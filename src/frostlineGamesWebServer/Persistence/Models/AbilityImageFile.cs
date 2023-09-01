using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class AbilityImageFile
{
    public int Id { get; set; }

    public bool Showcase { get; set; }

    public int AbilityId { get; set; }

    public virtual Abilitiess Ability { get; set; } = null!;

    public virtual File IdNavigation { get; set; } = null!;
}
