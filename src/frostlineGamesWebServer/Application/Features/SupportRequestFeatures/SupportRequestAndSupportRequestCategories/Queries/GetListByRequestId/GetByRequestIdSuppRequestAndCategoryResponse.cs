namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;

public class GetByRequestIdSuppRequestAndCategoryResponse
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
