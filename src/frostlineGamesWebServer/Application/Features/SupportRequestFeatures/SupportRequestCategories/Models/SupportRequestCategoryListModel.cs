using Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Models;

public class SupportRequestCategoryListModel
{
    public IList<SupportRequestCategoryListDto> Items { get; set; }
}
