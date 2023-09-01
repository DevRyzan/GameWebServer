using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class UserDetail
{
    public int Id { get; set; }

    public Guid? UserId { get; set; }

    public int? BasketId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Adress { get; set; }

    public bool? IsOnline { get; set; }

    public bool? IsBanned { get; set; }

    public DateTime? LoggedDate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<BannedAndUsersDetail> BannedAndUsersDetails { get; set; } = new List<BannedAndUsersDetail>();

    public virtual ICollection<SupportRequest> SupportRequests { get; set; } = new List<SupportRequest>();

    public virtual User? User { get; set; }

    public virtual ICollection<UserDetailImageFile> UserDetailImageFiles { get; set; } = new List<UserDetailImageFile>();
}
