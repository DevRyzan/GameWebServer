using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class HeroAndSkin
{
    public int Id { get; set; }

    public int HeroId { get; set; }

    public int SkinId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Hero Hero { get; set; } = null!;

    public virtual Skin Skin { get; set; } = null!;
}
