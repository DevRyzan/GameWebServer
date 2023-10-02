using Application.Features.SupportRequestFeatures.Tags.Dtos;
using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetList;

public class GetListTagQueryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TagPriority TagPriority { get; set; }
}
