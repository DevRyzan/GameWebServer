using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class EmailAuthenticator : Entity<int>
{
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public EmailAuthenticator()
    {
    }

    public EmailAuthenticator(int id, Guid userId, string? activationKey, bool isVerified) : base(id)
    {
        UserId = userId;
        ActivationKey = activationKey;
        IsVerified = isVerified;
    }
}