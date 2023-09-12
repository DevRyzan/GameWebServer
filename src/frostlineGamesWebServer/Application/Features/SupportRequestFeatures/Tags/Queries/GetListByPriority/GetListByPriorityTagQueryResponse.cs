using Application.Features.SupportRequestFeatures.Tags.Dtos;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetListByPriority;

public class GetListByPriorityTagQueryResponse
{
    public IList<TagListDto> Items { get; set; }
}
