namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Queries.GetListByRequestId;

public class GetListByRequestIdSuppRequestAndCategoryResponse
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
