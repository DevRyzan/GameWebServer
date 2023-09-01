using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public int AuthenticatorType { get; set; }

    public int RegisterType { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Bard> Bards { get; set; } = new List<Bard>();

    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = new List<EmailAuthenticator>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = new List<OtpAuthenticator>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<SupportRequestComment> SupportRequestComments { get; set; } = new List<SupportRequestComment>();

    public virtual UserDetail? UserDetail { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = new List<UserOperationClaim>();
}
