using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Delete;

public class DeleteTeamAndEmployeesCommandRequest : IRequest<DeleteTeamAndEmployeesCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, TeamAndEmployeeDelete };


}
