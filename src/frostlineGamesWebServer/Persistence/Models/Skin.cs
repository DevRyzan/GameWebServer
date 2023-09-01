using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Skin
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int Price { get; set; }

    public DateTime PurchasedDate { get; set; }

    public DateTime ReturnedDate { get; set; }

    public byte[] Bytes { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<HeroAndSkin> HeroAndSkins { get; set; } = new List<HeroAndSkin>();
}
