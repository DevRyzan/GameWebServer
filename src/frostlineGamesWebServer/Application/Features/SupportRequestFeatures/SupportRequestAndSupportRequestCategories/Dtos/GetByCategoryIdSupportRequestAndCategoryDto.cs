using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;

public class GetByCategoryIdSupportRequestAndCategoryDto
{
    public int Id { get; set; }
    public PageRequest PageRequest { get; set; }
}
