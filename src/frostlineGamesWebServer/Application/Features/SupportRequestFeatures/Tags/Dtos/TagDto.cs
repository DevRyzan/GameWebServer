namespace Application.Features.SupportRequestFeatures.Tags.Dtos;

public class TagDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public TagDto()
    {
    }

    public TagDto(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
}
