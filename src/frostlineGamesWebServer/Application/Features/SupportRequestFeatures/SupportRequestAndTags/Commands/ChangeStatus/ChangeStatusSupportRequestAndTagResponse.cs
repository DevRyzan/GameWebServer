using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.SupportRequestAndTags.Commands.ChangeStatus;

public class ChangeStatusSupportRequestAndTagResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
