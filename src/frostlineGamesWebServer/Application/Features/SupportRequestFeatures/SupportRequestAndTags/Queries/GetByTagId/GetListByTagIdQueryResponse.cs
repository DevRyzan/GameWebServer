using Core.Application.Dtos;



namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Queries.GetByTagId;

public class GetListByTagIdQueryResponse : IDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int TagId { get; set; }
    public string TagName { get; set; }
}
