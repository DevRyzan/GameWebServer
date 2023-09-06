using Domain.Entities.Users; 

namespace Persistence.Models;

public partial class SupportRequest
{
    public int Id { get; set; }

    public string? SupportRequestTitle { get; set; }

    public string? SupportRequestCoomment { get; set; }

    public string? UserIp { get; set; }

    public string? UserEmail { get; set; }

    public string? UserNickName { get; set; }

    public int? SupportRequestStatusType { get; set; }

    public int SupportRequestPriority { get; set; }

    public Guid? AssignedUserId { get; set; }

    public DateTime? AssignedTime { get; set; }

    public int SupportRequestCategoryId { get; set; }

    public Guid UserId { get; set; }

    public int UserDetailId { get; set; }

    public string? Code { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportRequestCategories { get; set; } = new List<SupportRequestAndSupportRequestCategory>();

    public virtual ICollection<SupportRequestAndTag> SupportRequestAndTags { get; set; } = new List<SupportRequestAndTag>();

    public virtual ICollection<SupportRequestComment> SupportRequestComments { get; set; } = new List<SupportRequestComment>();

    public virtual UserDetail UserDetail { get; set; } = null!;
}
