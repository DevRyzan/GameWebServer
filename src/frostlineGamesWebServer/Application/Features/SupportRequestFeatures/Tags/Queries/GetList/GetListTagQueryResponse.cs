using Application.Features.SupportRequestFeatures.Tags.Dtos;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetList;

public class GetListTagQueryResponse
{
    public IList<TagListDto> Items { get; set; }
}
