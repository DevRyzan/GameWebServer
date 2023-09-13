using Application.Features.SupportRequestFeatures.SupportRequestAndTags.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Models;

public class SupportRequestAndTagListModel
{
    public IList<SupportRequestAndTagListDto> Items { get; set; }
}