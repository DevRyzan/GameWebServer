using Domain.Entities.Users;

namespace Persistence.Models;

public partial class UserDetailImageFile
{
    public int Id { get; set; }

    public bool Showcase { get; set; }

    public int UserDetailId { get; set; }

    public virtual File IdNavigation { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
