namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class CreatedPossibleRequestAndTagDto
{
    public int Id { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }
    public bool Status { get; set; }

    public DateTime CreatedDate { get; set; }


}
