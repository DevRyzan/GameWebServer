namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class UpdatedPossibleRequestAndTagDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }
    public DateTime? UpdatedDate { get; set; }

}
