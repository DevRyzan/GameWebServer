using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.AssignToEmployee;

public class AssignToEmployeeSupportRequestCommandResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
    public string? UserIP { get; set; }
    public Guid? UserId { get; set; }
    public string? UserEmail { get; set; }
    public string? UserNickName { get; set; }
    public Guid? AssignedUserId { get; set; }
    public SupportRequestStatusType? SupportRequestStatusType { get; set; }
    public int SupportRequestCategoryId { get; set; }
}
