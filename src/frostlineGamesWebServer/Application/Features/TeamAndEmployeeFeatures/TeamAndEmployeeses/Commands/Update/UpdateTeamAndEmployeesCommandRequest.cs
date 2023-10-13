using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.TeamAndEmployeeses.Commands.Update;

public class UpdateTeamAndEmployeesCommandRequest : IRequest<UpdateTeamAndEmployeesCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public Guid EmployeeId { get; set; }

    public string[] Roles => new[] { Admin, TeamAndEmployeeUpdate };

}

