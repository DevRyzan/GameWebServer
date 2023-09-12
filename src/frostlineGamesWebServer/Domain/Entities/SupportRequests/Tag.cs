using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class Tag : Entity<int>
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int TagPriority { get; set; }

    public virtual ICollection<PossibleRequestAndTag> PossibleRequestAndTags { get; set; } = new List<PossibleRequestAndTag>();

    public virtual ICollection<SupportRequestAndTag> SupportRequestAndTags { get; set; } = new List<SupportRequestAndTag>();


}
