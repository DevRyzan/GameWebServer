using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetById;

public class GetByIdRequestAndTagQueryResponse : IDto
{
    public int Id { get; set; }
    public int SupportRequestId { get; set; }
    public string SupportRequestComment { get; set; }
    public string SupportRequestTitle { get; set; }
    public int TagId { get; set; }
    public string TagName { get; set; }
}
