using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class SupportRequestDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Topic { get; set; }
    public string? Comment { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? UserEmail { get; set; }
    public string? UserNickName { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
    public bool? Status { get; set; }
    public int? SupportRequestCategoryId { get; set; }
}
