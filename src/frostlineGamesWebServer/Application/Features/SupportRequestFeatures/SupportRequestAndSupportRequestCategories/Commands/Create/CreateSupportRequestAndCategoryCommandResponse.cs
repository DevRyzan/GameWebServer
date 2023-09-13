namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Create;


public class CreateSupportRequestAndCategoryCommandResponse
{
    public int Id { get; set; }
    public int SupportRequestId { get; set; }
    public int SupportRequestCategoryId { get; set; }
}
