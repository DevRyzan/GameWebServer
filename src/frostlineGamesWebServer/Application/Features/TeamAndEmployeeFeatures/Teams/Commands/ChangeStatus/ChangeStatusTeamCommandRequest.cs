using MediatR;
using Core.Application.Transaction;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.ChangeStatus;

public class ChangeStatusTeamCommandRequest : IRequest<ChangeStatusTeamCommandResponse>, ITransactionalRequest
{
    public int Id { get; set; }
}