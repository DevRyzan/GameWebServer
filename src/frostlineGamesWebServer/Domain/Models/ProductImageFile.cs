using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class ProductImageFile
{
    public int Id { get; set; }

    public bool Showcase { get; set; }

    public int ProductsId { get; set; }

    public virtual File IdNavigation { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;
}
