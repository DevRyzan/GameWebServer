using Core.Application.Pipelines.Authorization;
using Core.Application.Transaction;
using MediatR;
using static Application.Feature.TeamFeatures.Employees.Constants.OperationClaims;
using static Domain.Constants.OperationClaims;


namespace Application.Features.TeamAndEmployeeFeatures.Employees.Commands.Update;


public class UpdateEmployeeCommandRequest : IRequest<UpdateEmployeeCommandResponse>, ISecuredRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => new[] { Admin, EmployeeUpdate };

}