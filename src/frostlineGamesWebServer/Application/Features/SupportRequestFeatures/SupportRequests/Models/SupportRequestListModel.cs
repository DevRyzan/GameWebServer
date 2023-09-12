using Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Models;

public class SupportRequestListModel
{
    public IList<SupportRequestListDto> Items { get; set; }
}
