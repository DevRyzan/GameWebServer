using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class OurGame
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string IconUrl { get; set; } = null!;

    public int GameCategoryId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual GameCategory GameCategory { get; set; } = null!;
}
