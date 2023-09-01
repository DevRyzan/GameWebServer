using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
