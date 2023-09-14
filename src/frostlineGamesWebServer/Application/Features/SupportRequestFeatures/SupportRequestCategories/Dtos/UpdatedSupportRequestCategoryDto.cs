namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Dtos;

public class UpdatedSupportRequestCategoryDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? TagId { get; set; }
    public bool Status { get; set; }

    public UpdatedSupportRequestCategoryDto()
    {

    }

    public UpdatedSupportRequestCategoryDto(string? name, string? description, int? tagId)
    {
        Name = name;
        Description = description;
        TagId = tagId;
    }
}
