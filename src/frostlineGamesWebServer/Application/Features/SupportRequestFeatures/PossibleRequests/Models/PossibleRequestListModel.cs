using Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SupportRequestFeatures.PossibleRequests.Models;

public class PossibleRequestListModel : BasePageableModel
{
    public IList<PossibleRequestListDto> Items { get; set; }

}
