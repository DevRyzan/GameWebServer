using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestCategories.Commands.ChangeStatus;

public class ChangeStatusSupportRequestCategoryResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
