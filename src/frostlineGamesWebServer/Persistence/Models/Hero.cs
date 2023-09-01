using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Hero
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Region { get; set; }

    public int? DifficultLevel { get; set; }

    public int? HeroType { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Abilitiess> Abilitiesses { get; set; } = new List<Abilitiess>();

    public virtual ICollection<BardAndHero> BardAndHeroes { get; set; } = new List<BardAndHero>();

    public virtual ICollection<HeroAndSkin> HeroAndSkins { get; set; } = new List<HeroAndSkin>();

    public virtual HeroDetail? HeroDetail { get; set; }

    public virtual HeroStat? HeroStat { get; set; }

    public virtual ICollection<HeroStory> HeroStories { get; set; } = new List<HeroStory>();
}
