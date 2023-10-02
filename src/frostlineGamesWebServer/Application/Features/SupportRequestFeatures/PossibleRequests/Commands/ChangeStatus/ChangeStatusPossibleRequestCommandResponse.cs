using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.ChangeStatus;

public class ChangeStatusPossibleRequestCommandResponse : IDto
{
    public int Id { get; set; }
    public bool Status { get; set; }
}
