using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class GetListByIdSupportRequestDto<TId>
{
    public TId Id { get; set; }
    public PageRequest PageRequest { get; set; }
}
