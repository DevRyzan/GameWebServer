using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetListByInActiveListByAssignedUserIdDto
{
    public Guid AssignedUserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
