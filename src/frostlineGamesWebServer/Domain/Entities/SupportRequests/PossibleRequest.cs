using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class PossibleRequest : Entity<int>
{
    public string RequestName { get; set; } = null!;

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public int SupportRequestCategoryId { get; set; }

    public int PopularityCount { get; set; }

    public virtual ICollection<PossibleRequestAndTag> PossibleRequestAndTags { get; set; } = new List<PossibleRequestAndTag>();

    public virtual SupportRequestCategory SupportRequestCategory { get; set; } = null!;
}
