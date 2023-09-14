using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndSupportRequestCategories.Commands.ChangeStatus;

public class ChangeStatusSupportRequestAndCategoryResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
