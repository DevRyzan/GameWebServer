using Core.Application.Transaction;
using MediatR;
using static Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Remove;

public class RemoveTeamAndEmployeesCommandRequest : IRequest<RemoveTeamAndEmployeesCommandResponse>, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, TeamAndEmployeeRemove };

}