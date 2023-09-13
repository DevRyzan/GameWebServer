using Core.Application.Dtos;

namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetById;
public class GetByIdSuppRequestAndCategoryResponse : IDto
{
    public int Id { get; set; }
    public int SupportRequestId { get; set; }
    public string SupportRequestTitle { get; set; }
    public string SupportRequestComment { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public string? SupportRequestCategoryName { get; set; }


}

