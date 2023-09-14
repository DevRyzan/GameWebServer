using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListInActiveByCreatedDate;

public class GetListInActiveByCreatedDateSupportRequestQueryResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public Guid UserId { get; set; }
    public int UserDetailId { get; set; }
    public string? UserEmail { get; set; }
    public string? UserNickName { get; set; }
    public string UserImagePath { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }
    public bool? Status { get; set; }
    public int? SupportRequestCategoryId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
