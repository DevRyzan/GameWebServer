using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.ChangeStatusType;

public class ChangeStatusTypeSupportRequestCommandResponse
{
    public int Id { get; set; }
    public SupportRequestStatusType SupportRequestStatusType { get; set; }
}
