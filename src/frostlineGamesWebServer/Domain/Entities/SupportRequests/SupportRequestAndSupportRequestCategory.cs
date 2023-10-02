using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class SupportRequestAndSupportRequestCategory : Entity<int>
{
    public int SupportRequestCategoryId { get; set; }

    public int SupportRequestId { get; set; }

    public virtual SupportRequest SupportRequest { get; set; } = null!;

    public virtual SupportRequestCategory SupportRequestCategory { get; set; } = null!;
}
