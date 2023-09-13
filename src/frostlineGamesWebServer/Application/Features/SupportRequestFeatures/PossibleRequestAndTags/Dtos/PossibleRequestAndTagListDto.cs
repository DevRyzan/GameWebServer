namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class PossibleRequestAndTagListDto
{
    public int Id { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }
    public bool Status { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}
