using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;

public class GetListByIdSupportRequestAndCategoryDto<TId>
{
    public TId Id { get; set; }
    public PageRequest PageRequest { get; set; }
}
