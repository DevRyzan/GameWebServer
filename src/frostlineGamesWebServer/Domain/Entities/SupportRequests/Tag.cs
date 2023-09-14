using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.SupportRequests;

public class Tag : Entity<int>
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public TagPriority TagPriority { get; set; }

    public virtual ICollection<PossibleRequestAndTag> PossibleRequestAndTags { get; set; } = new List<PossibleRequestAndTag>();

    public virtual ICollection<SupportRequestAndTag> SupportRequestAndTags { get; set; } = new List<SupportRequestAndTag>();


}
