namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class CreatedSupportRequestDto
{

    public int SupportRequestCategoryId { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }

}
