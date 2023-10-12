using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using static Application.Feature.TeamFeatures.Employees.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;
using MediatR;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Delete;

public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, EmployeeDelete };

}