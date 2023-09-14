using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListActiveByLoggedId;

public class GetActiveListByLoggedIdSupportRequestQueryResponse
{
    public int Id { get; set; }
    public string? SupportRequestTitle { get; set; }
    public string? SupportRequestCoomment { get; set; }
    public string? UserIP { get; set; }
    public Guid? UserId { get; set; }
    public int? UserDetailId { get; set; }
    public string? UserEmail { get; set; }
    public string? UserNickName { get; set; }
    public Guid? AssignedUserId { get; set; }
    public string? UserImagePath { get; set; }
    public SupportRequestStatusType? SupportRequestStatusType { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime AssignedTime { get; set; }
}
