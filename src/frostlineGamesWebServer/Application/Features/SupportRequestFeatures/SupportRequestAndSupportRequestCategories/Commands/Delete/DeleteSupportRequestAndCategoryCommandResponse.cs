namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Delete;

public class DeleteSupportRequestAndCategoryCommandResponse
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int CategoryId { get; set; }
    public bool Status { get; set; }
}
