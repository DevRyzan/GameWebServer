using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.Remove;

public class RemoveSupportRequestAndCategoryCommandResponse : IDto
{
    public int Id { get; set; }
    public bool IsRemoved { get; set; }
}
