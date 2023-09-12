using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class SupportRequestAndTag : Entity<int>
{

    public int SupportRequestId { get; set; }

    public int TagId { get; set; }

    public virtual SupportRequest Request { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
