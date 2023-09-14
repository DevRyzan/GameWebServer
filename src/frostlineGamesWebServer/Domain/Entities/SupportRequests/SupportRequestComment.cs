using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.SupportRequests;

public class SupportRequestComment : Entity<int>
{

    public string UserName { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public bool IsEdited { get; set; }

    public int SupportRequestId { get; set; }

    public Guid UserId { get; set; }

    public virtual SupportRequest  SupportRequest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
