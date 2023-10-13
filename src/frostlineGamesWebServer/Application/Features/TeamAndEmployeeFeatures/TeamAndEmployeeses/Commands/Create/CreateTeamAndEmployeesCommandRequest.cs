using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Create;

public class CreateTeamAndEmployeesCommandRequest : IRequest<CreatedTeamAndEmployeesCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }

    public string[] Roles => new[] { Admin, TeamAndEmployeeAdd };
}
