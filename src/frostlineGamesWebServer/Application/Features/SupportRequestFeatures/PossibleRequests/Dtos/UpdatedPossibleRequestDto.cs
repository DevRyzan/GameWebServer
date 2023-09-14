namespace Application.Features.SupportRequestFeatures.PossibleRequests.Dtos;

public class UpdatedPossibleRequestDto
{
    public int Id { get; set; }
    public string RequestName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public bool Status { get; set; }
}
