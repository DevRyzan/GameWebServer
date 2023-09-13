using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.SupportRequests.Commands.Update;

public class UpdateSupportRequestCommandResponse
{
    public int SupportRequestCategoryId { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public SupportRequestPriority SupportRequestPriority { get; set; }
}
