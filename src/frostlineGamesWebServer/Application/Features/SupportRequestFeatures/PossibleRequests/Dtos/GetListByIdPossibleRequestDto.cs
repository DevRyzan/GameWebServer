using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;

public class GetListByIdPossibleRequestDto<TId>
{
    public TId Id { get; set; }
    public PageRequest PageRequest { get; set; }
}
