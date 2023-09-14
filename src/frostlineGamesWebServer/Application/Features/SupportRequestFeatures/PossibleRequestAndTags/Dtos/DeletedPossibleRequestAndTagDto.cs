namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class DeletedPossibleRequestAndTagDto
{
    public int Id { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }
    public bool Status { get; set; }

    public DateTime DeletedDate { get; set; }
}
