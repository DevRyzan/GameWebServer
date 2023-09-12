namespace Application.Features.SupportRequestFeatures.SupportRequests.Dtos;

public class UpdatedSupportRequestDto
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Topic { get; set; }
    public string? Comment { get; set; }
}