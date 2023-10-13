using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using static Application.Features.TeamAndEmployeeFeatures.Teams.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Delete;

public class DeleteTeamCommandRequest : IRequest<DeleteTeamCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, TeamDelete };

}
