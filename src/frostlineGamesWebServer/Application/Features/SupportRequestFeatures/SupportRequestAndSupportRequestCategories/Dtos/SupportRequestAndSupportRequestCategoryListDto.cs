namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Dtos;

public class SupportRequestAndSupportRequestCategoryListDto
{
    public int Id{ get; set; }
    public int RequestId { get; set; }
    public int CategoryId { get; set; }

    public SupportRequestAndSupportRequestCategoryListDto()
    {

    }
    public SupportRequestAndSupportRequestCategoryListDto(int requestId, int categoryId)
    {
        RequestId = requestId;
        CategoryId = categoryId;
    }
}
