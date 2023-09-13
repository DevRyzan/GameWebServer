namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;

public class CreatedSupportRequestCategoryDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public CreatedSupportRequestCategoryDto()
    {

    }

    public CreatedSupportRequestCategoryDto(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
}
