using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string Heading { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;

    public Guid UserId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
