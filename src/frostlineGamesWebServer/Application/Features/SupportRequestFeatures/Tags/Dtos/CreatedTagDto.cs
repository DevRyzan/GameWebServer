using Domain.Enums;

namespace Application.Features.SupportRequestFeatures.Tags.Dtos;

public class CreatedTagDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    public TagPriority TagPriority { get; set; }

}
