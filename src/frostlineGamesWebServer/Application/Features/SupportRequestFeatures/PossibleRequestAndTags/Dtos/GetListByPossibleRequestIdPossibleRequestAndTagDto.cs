using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class GetListByPossibleRequestIdPossibleRequestAndTagDto
{
    public int PossibleRequestId { get; set; }
    public PageRequest PageRequest { get; set; }
}
