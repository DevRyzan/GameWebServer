using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Core.Security.Entities;

public class User : Entity<Guid>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
    public RegisterType RegisterType { get; set; }



    public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
    public virtual ICollection<EmailAuthenticator>? EmailAuthenticators { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
        EmailAuthenticators = new HashSet<EmailAuthenticator>();
    }



    public User(Guid id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType) : base()
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        AuthenticatorType = authenticatorType;
    }
}