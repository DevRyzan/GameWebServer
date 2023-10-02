using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Queries.GetByIdForAdmin;

public class GetByIdForAdminPossibleRequestQueryResponse : IDto
{
    public int Id { get; set; }
    public string RequestName { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int PopularityCount { get; set; }
    public int SupportRequestCategoryId { get; set; }
    public int SupportRequestCategoryName { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
