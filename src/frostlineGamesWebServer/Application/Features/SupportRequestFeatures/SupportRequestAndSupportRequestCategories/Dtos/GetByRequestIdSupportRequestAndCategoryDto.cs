using Core.Application.Requests;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;

public class GetByRequestIdSupportRequestAndCategoryDto
{
    public int RequestId { get; set; }
    public PageRequest PageRequest { get; set; }
}
