using Core.Persistence.Repositories;

namespace Domain.Entities.SupportRequests;

public class PossibleRequestAndTag : Entity<int>
{
    public int PossibleRequestId { get; set; }

    public int TagId { get; set; }

    public virtual PossibleRequest PossibleRequest { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
