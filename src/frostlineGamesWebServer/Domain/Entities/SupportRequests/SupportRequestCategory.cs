using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class SupportRequestCategory : Entity<int>
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<PossibleRequest> PossibleRequests { get; set; } = new List<PossibleRequest>();

    public virtual ICollection<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportRequestCategories { get; set; } = new List<SupportRequestAndSupportRequestCategory>();
}
