namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Dtos;

public class PossibleRequestAndTagDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
    public int PossibleRequestId { get; set; }
    public string PossibleRequestName { get; set; }
    public string? PossibleRequestTitle { get; set; }
    public string? PossibleRequestComment { get; set; }
    public int TagId { get; set; }
    public string? TagName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
