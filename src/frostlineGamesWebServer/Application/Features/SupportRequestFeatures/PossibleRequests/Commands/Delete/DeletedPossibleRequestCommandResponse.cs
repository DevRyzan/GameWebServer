using Core.Application.Dtos;


namespace Application.Features.SupportRequestFeatures.PossibleRequests.Commands.Delete;

public class DeletedPossibleRequestCommandResponse : IDto
{
    public int Id { get; set; }
    public string RequestName { get; set; }
    public bool Status { get; set; }

}
