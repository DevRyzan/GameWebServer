using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;

public class GetListByTagIdSupportRequestAndTagDto
{
    public int TagId { get; set; }
    public PageRequest PageRequest { get; set; }
}
