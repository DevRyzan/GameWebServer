using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Models;

namespace Domain.Entities.Bards;

public class Bard : Entity<int>
{

    public Guid UserId { get; set; }

    public int BarDetailId { get; set; }

    public int BardIconId { get; set; }

    public string NickName { get; set; } = null!;

    public string IconUrl { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<BardAndEloRank> BardAndEloRanks { get; set; } = new List<BardAndEloRank>();

    public virtual ICollection<BardAndHero> BardAndHeroes { get; set; } = new List<BardAndHero>();

    public virtual ICollection<BardAndLevel> BardAndLevels { get; set; } = new List<BardAndLevel>();

    public virtual ICollection<BardAndMatchesRate> BardAndMatchesRates { get; set; } = new List<BardAndMatchesRate>();

    public virtual BardDetail? BardDetail { get; set; }

    public virtual ICollection<BardEloRankPoint> BardEloRankPoints { get; set; } = new List<BardEloRankPoint>();

    public virtual ICollection<BardExperiencePoint> BardExperiencePoints { get; set; } = new List<BardExperiencePoint>();

    public virtual BardIcon BardIcon { get; set; } = null!;

    public virtual ICollection<BardImageFİle> BardImageFİles { get; set; } = new List<BardImageFİle>();

    public virtual ICollection<ContributionPoint> ContributionPoints { get; set; } = new List<ContributionPoint>();

    public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();

    public virtual ICollection<EndOfMatchInventory> EndOfMatchInventories { get; set; } = new List<EndOfMatchInventory>();

    public virtual ICollection<GamCredit> GamCredits { get; set; } = new List<GamCredit>();

    public virtual User User { get; set; } = null!;
}
