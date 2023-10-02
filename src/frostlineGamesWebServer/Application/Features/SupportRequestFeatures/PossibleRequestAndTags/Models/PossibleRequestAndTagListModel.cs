using Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Models;

public class PossibleRequestAndTagListModel
{
    public IList<PossibleRequestAndTagListDto> Items { get; set; }

}
