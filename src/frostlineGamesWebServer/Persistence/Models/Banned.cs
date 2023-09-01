using System;
using System.Collections.Generic;

namespace Persistence.Models;

public partial class Banned
{
    public int Id { get; set; }

    public string? BanName { get; set; }

    public string? Description { get; set; }

    public int? BanHours { get; set; }

    public bool? IsBanned { get; set; }

    public bool? IsChatBan { get; set; }

    public bool? IsVoiceBan { get; set; }

    public bool? IsGameBan { get; set; }

    public Guid? UserId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<BannedAndUsersDetail> BannedAndUsersDetails { get; set; } = new List<BannedAndUsersDetail>();
}
