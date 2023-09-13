namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Queries.GetListActiveByRequestId;

public class GetListActiveByPossibleRequestIdQueryResponse
{
    public int Id { get; set; }
    public int PossibleRequestId { get; set; }
    public int TagId { get; set; }
    public string TagName { get; set; }
    public bool Status { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
