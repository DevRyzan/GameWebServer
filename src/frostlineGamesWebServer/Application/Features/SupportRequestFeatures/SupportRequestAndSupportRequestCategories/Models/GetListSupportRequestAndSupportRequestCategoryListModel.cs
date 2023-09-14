using Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Models;

public class GetListSupportRequestAndSupportRequestCategoryListModel : BasePageableModel
{
    public IList<SupportRequestAndSupportRequestCategoryListDto> Items { get; set; }
}
