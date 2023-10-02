using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetByTagIdSupportRequestDto
{
    public int TagId { get; set; }
    public PageRequest PageRequest { get; set; }
}
