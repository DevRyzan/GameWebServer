namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class RemovedPossibleRequestAndTagDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }

}
