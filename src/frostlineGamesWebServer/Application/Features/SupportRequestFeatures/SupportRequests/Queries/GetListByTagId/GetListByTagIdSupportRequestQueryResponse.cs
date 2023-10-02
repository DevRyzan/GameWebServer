using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Queries.GetListByTagId;

public class GetListByTagIdSupportRequestQueryResponse
{
    public int? Id { get; set; }
    public Guid? UserId { get; set; }
    public string? UserNickName { get; set; }
    public string? UserEmail { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }
}
