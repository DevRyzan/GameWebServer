using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class ChangedStatusSupportRequestDto
{
    public int Id { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
}
