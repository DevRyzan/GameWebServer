using Core.Persistence.Repositories;
using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities.SupportRequests;

public class SupportRequest : Entity<int>
{
    public string? SupportRequestTitle { get; set; }

    public string? SupportRequestComment { get; set; }

    public string? UserIp { get; set; }

    public string? UserEmail { get; set; }

    public string? UserNickName { get; set; }
    public bool CanWriteBack { get; set; }

    public SupportRequestStatusType? SupportRequestStatusType { get; set; }

    public SupportRequestPriority SupportRequestPriority { get; set; }

    public Guid? AssignedUserId { get; set; }

    public DateTime? AssignedTime { get; set; }

    public int SupportRequestCategoryId { get; set; }

    public Guid UserId { get; set; }

    public int UserDetailId { get; set; }

    public virtual ICollection<SupportRequestAndSupportRequestCategory> SupportRequestAndSupportRequestCategories { get; set; } = new List<SupportRequestAndSupportRequestCategory>();

    public virtual ICollection<SupportRequestAndTag> SupportRequestAndTags { get; set; } = new List<SupportRequestAndTag>();

    public virtual ICollection<SupportRequestComment> SupportRequestComments { get; set; } = new List<SupportRequestComment>();

    public virtual UserDetail UserDetail { get; set; } = null!;
}
