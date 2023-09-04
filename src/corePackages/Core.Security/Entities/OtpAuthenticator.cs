using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Security.Entities;

public class OtpAuthenticator : Entity<int>
{

    public Guid UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }

    public OtpAuthenticator()
    {
    }

    public OtpAuthenticator(int id, Guid userId, byte[] secretKey, bool isVerified) : this()
    {
        Id = id;
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = isVerified;
    }
}