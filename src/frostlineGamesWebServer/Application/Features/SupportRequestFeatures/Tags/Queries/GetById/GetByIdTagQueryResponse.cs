using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Queries.GetById;

public class GetByIdTagQueryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TagPriority TagPriority { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDaqte { get; set; }
}
