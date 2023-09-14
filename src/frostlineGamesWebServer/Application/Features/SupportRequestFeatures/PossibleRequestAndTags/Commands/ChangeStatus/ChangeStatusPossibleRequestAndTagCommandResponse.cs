using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.PossibleRequestAndTags.Commands.ChangeStatus;

public class ChangeStatusPossibleRequestAndTagCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
