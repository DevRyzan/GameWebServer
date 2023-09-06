using Domain.Entities.Users; 

namespace Persistence.Models;

public partial class BannedAndUsersDetail
{
    public int Id { get; set; }

    public int UserDetailId { get; set; }

    public int BannedId { get; set; }

    public DateTime? BeginingBanDate { get; set; }

    public DateTime? EndingBanDate { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual Banned Banned { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
