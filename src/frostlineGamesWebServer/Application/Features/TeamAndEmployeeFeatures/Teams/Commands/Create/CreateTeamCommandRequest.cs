using static Application.Features.TeamAndEmployeeFeatures.Teams.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Teams.Commands.Create;

public class CreateTeamCommandRequest : IRequest<CreateTeamCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, TeamAdd };

}