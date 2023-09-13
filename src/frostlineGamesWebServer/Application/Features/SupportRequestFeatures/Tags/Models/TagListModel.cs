using Application.Features.SupportRequestFeatures.Tags.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SupportRequestFeatures.Tags.Models;

public class TagListModel
{
    public IList<TagListDto> Items { get; set; }
}
