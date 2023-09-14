using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetByUserIdSupportRequestDto
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }
}
