using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetListByListByAssignedUserIdDto
{
    public Guid AssignedUserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
