using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.TeamFeatures.Employees.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Remove;

public class RemoveEmployeeCommandRequest : IRequest<RemoveEmployeeCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, EmployeeRemove };

}
