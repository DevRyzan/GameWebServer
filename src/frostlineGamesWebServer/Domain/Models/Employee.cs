using Core.Security.Entities; 

namespace Persistence.Models;

public partial class Employee
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<TeamAndEmployee> TeamAndEmployees { get; set; } = new List<TeamAndEmployee>();

    public virtual User User { get; set; } = null!;
}
